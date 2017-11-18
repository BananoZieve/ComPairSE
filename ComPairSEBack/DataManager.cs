using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;
using ComPairSE.Properties;
using System.Xml.Linq;


namespace ComPairSE
{
    public interface IDataManager
    {
        void LoadData();
        void SaveData();
        void AddItem(Item product);
        List<Item> GetItems(params string[] tags);
        void AddReceipt(Receipt receipt);
        List<dynamic> GetReceipts(DateTime date);
        List<dynamic> GetReceipts();
        dynamic GetReceiptByID(int id);
        void ClarificationSystem(Item item);
    }

    public class DataManager : IDataManager
    {
        protected DataTable productsTable;
        protected DataTable tagsTable;
        protected DataTable unionTable;
        private DataSet dataSet = new DataSet();
        protected DataTable dtClarifyWords;
        protected DataTable receiptsTable;
        private DataSet dataSetReceipts = new DataSet();


        public List<Item> GetItems(params string[] tags)
        {
            List<int> tagIds = new List<int>();
            List<int> itemIds = new List<int>();
            List<Item> ret = new List<Item>();

            // get tag ids
            if (tags != null)
            {
                tags = tags.Distinct().ToArray();
                foreach (string tag in tags)
                {
                    DataRow row = tagsTable.Rows.Find(tag);
                    if (row != null)
                        tagIds.Add((int)row["tagId"]);
                }
            }

            // get item ids
            if (tagIds.Count > 0)
            {
                foreach (DataRow row in unionTable.Rows)
                {
                    foreach (int id in tagIds)
                    {
                        if ((int)row["tagId"] == id)
                        {
                            itemIds.Add((int)row["itemId"]);
                            break;
                        }
                    }
                }
            }

            // sort item ids by appearence count
            var ordered = itemIds
                .GroupBy(id => id)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key);

            // create item list
            foreach (int itemId in ordered)
            {
                DataRow row = productsTable.Rows.Find(itemId);
                ret.Add(RowToItem(row));
            }

            return ret;
        }

        private Item RowToItem(DataRow row)
        {
            int id = (int)row["itemId"];
            string name = (string)row["name"];
            int[] prices = new int[row.ItemArray.Length - 2];
            for (int i = 0; i < prices.Length; i++)
                prices[i] = row[i + 2] != DBNull.Value ? (int)row[i + 2] : 0;

            return new Item(name, prices, id: id);
        }

        public void CreateDataTables()
        {
            productsTable = new DataTable("Items");
            productsTable.Columns.Add("itemId", typeof(int));
            productsTable.Columns.Add("name", typeof(string));
            foreach (string shop in Enum.GetNames(typeof(ShopEnum)))
                productsTable.Columns.Add("price" + shop, typeof(int));

            tagsTable = new DataTable("Tags");
            tagsTable.Columns.Add("tagId", typeof(int));
            tagsTable.Columns.Add("name", typeof(string));

            unionTable = new DataTable("ItemsTags");
            unionTable.Columns.Add("itemId", typeof(int));
            unionTable.Columns.Add("tagId", typeof(int));

            dtClarifyWords = new DataTable("ClarifyWords");
            dtClarifyWords.Columns.Add("ID", typeof(int));
            dtClarifyWords.Columns.Add("nameBefore", typeof(string));
            dtClarifyWords.Columns.Add("nameAfter", typeof(string));

            receiptsTable = new DataTable("Receipts");
            receiptsTable.Columns.Add("receiptID", typeof(int));
            receiptsTable.Columns.Add("date", typeof(DateTime));
            receiptsTable.Columns.Add("shop", typeof(ShopEnum));
            receiptsTable.Columns.Add("price", typeof(int));
            receiptsTable.Columns.Add("items", typeof(string));

        }

        public void InitDataTables()
        {
            DataColumn columnItemId = productsTable.Columns["itemId"];
            columnItemId.AutoIncrement = true;
            columnItemId.AutoIncrementSeed = 1;
            columnItemId.AutoIncrementStep = 1;
            productsTable.PrimaryKey = new DataColumn[] { columnItemId };

            DataColumn columnTagId = tagsTable.Columns["tagId"];
            columnTagId.AutoIncrement = true;
            columnTagId.AutoIncrementSeed = 1;
            columnTagId.AutoIncrementStep = 1;
            tagsTable.PrimaryKey = new DataColumn[] { tagsTable.Columns["name"] };

            DataColumn columnClarifyId = dtClarifyWords.Columns["ID"];
            columnClarifyId.AutoIncrement = true;
            columnClarifyId.AutoIncrementSeed = 1;
            columnClarifyId.AutoIncrementStep = 1;
            dtClarifyWords.PrimaryKey = new DataColumn[] { columnClarifyId };

            DataColumn columnReceiptId = receiptsTable.Columns["receiptID"];
            columnReceiptId.AutoIncrement = true;
            columnReceiptId.AutoIncrementSeed = 1;
            columnReceiptId.AutoIncrementStep = 1;
            receiptsTable.PrimaryKey = new DataColumn[] { columnReceiptId };
        }

        public void AddItem(Item item)
        {
            List<Item> found = GetItems(item.Tags);
            if (!found.Contains(item))
            {
                // add new entry to database
                DataRow itemRow = productsTable.Rows.Add(
                    null,
                    item.Name,
                    item.Prices[(int)ShopEnum.Maxima],
                    item.Prices[(int)ShopEnum.Norfa],
                    item.Prices[(int)ShopEnum.Rimi],
                    item.Prices[(int)ShopEnum.Iki]);

                int itemId = (int)itemRow["itemId"];

                foreach (string tag in item.Tags)
                {
                    DataRow tagRow = tagsTable.Rows.Find(tag);
                    if (tagRow == null)
                        tagRow = tagsTable.Rows.Add(null, tag);
                    int tagId = (int)tagRow["tagId"];
                    unionTable.Rows.Add(itemId, tagId);
                }
            }
            else
            {
                // update existing entry
                DataRow itemRow = productsTable.Rows.Find(found[0].Id);
                int i = 2;
                foreach (int price in item.Prices)
                    if (price > 0)
                        itemRow[i++] = price;

            }
        }

        public void AddReceipt(Receipt receipt)
        {
            DataRow itemRow = receiptsTable.Rows.Add(
                null,
                receipt.PurchaseTime,
                receipt.ShopEnum,
                receipt.Total,
                Util.ObjToString(receipt.Items));
        }

        public List<dynamic> GetReceipts(DateTime date)
        {
            var receipts = from row in receiptsTable.AsEnumerable()
                              where ((DateTime)row["date"]).Date == date
                              select new { ID = (int)row["receiptID"], Date = (DateTime)row["date"], Price = (int)row["price"], Shop = ((ShopEnum)row["shop"]).ToString() };

            return receipts.Cast<dynamic>().ToList();
        }

        public List<dynamic> GetReceipts()
        {
            var allReceipts = from row in receiptsTable.AsEnumerable()
                              select new { ID = (int)row["receiptID"], Date = (DateTime)row["date"], Price = (int)row["price"], Shop = ((ShopEnum)row["shop"]).ToString() };
            //  select Receipt.Create((ShopEnum)row["shop"], Util.StringToObj<Item>((string)row["items"]), (DateTime)row["date"], (int)row["price"]);

            return allReceipts.Cast<dynamic>().ToList();
        }

        public dynamic GetReceiptByID(int id)
        {
            var receipt = (from row in receiptsTable.AsEnumerable()
                           where ((int)row["receiptID"]) == id
                           select new { ID = (int)row["receiptID"], ShopEnum = (ShopEnum)row["shop"], Items = Util.StringToObj<Item>((string)row["items"]) , Total = (int)row["price"]}).First();
            return receipt;
        }


        public virtual void LoadData()
        {
            if (
                File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.ItemsTableFile) &&
                File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.TagsTableFile) &&
                File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.ItemsTagsTableFile) &&
                File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.ReceiptsTableFile)
                )
            {
                productsTable = new DataTable();
                tagsTable = new DataTable();
                unionTable = new DataTable();
                dtClarifyWords = new DataTable();
                receiptsTable = new DataTable();
                productsTable.ReadXml(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.ItemsTableFile);
                tagsTable.ReadXml(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.TagsTableFile);
                unionTable.ReadXml(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.ItemsTagsTableFile);
                receiptsTable.ReadXml(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.ReceiptsTableFile);
                //dtClarifyWords.ReadXml("AppDomain.CurrentDomain.BaseDirectory" + @"/" + Resources.ExplainedWordsTableFile);
            }
            else
            {
                CreateDataTables();
                InitDataTables();
            }
        }

        public virtual void SaveData()
        {
            productsTable.WriteXml(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.ItemsTableFile, XmlWriteMode.WriteSchema);
            tagsTable.WriteXml(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.TagsTableFile, XmlWriteMode.WriteSchema);
            unionTable.WriteXml(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.ItemsTagsTableFile, XmlWriteMode.WriteSchema);
            receiptsTable.WriteXml(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.ReceiptsTableFile, XmlWriteMode.WriteSchema);
           // dtClarifyWords.WriteXml(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.ExplainedWordsTableFile, XmlWriteMode.WriteSchema);
        }

        //Clarification system for words with dot 
        public void ClarificationSystem(Item item)
        {
            string rightValue;

            foreach (string words in item.Tags)
            {
                if (words.Contains("."))
                {
                    string[] wordsArraySplitByDot = words.Split('.');

                    foreach (string word in wordsArraySplitByDot)
                    {
                        if (!word.Equals(""))
                        {
                            XDocument doc = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/" + Resources.ExplainedWordsTableFile);

                            var wordExist = doc.Descendants("ClarifyWords")
                                .Any(x => (string)x.Element("nameBefore") == word);

                            if (!wordExist)
                            {
                                rightValue = Interaction.InputBox(word, "Can you clarify this word?", "Default Value", -1, -1);

                                DataRow systemRow = dtClarifyWords.Rows.Add(
                                    null,
                                    word,
                                    rightValue);
                            }
                        }
                    }
                }
            }
        }
    }

    public class DemoDataManager : DataManager
    {
        public override void LoadData()
        {
            CreateDataTables();
            InitDataTables();
            InitTestTables();
        }

        public override void SaveData()
        {
            // Saving disabled
        }

        private void InitTestTables()
        {
            // HARD-CODE
            productsTable.Rows.Add(null, "Dvaro Pienas 1l", 1, 3, 10, 52);
            productsTable.Rows.Add(null, "Rokiskio Pienas 2l", 1, 3, 10, 52);
            productsTable.Rows.Add(null, "Bandele su varske", 1, 3, 10, 52);
            productsTable.Rows.Add(null, "Bandele su cinamonu", 1, 3, 10, 52);
            productsTable.Rows.Add(null, "Dvaro grietine", 1, 3, 10, 52);

            tagsTable.Rows.Add(null, "Dvaro");
            tagsTable.Rows.Add(null, "Pienas");
            tagsTable.Rows.Add(null, "Rokiskio");
            tagsTable.Rows.Add(null, "Bandele");
            tagsTable.Rows.Add(null, "su varske");
            tagsTable.Rows.Add(null, "su cinamonu");
            tagsTable.Rows.Add(null, "grietine");

            unionTable.Rows.Add(1, 1);
            unionTable.Rows.Add(1, 2);
            unionTable.Rows.Add(2, 2);
            unionTable.Rows.Add(2, 3);
            unionTable.Rows.Add(3, 4);
            unionTable.Rows.Add(3, 5);
            unionTable.Rows.Add(4, 4);
            unionTable.Rows.Add(4, 6);
            unionTable.Rows.Add(5, 1);
            unionTable.Rows.Add(5, 7);
        }
    }
}
