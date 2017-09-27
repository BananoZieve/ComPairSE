using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ComPairSE
{
    public interface IDataManager
    {
        void LoadData();
        void SaveData();
        void AddItem(Item product);
        List<Item> GetItems(params string[] tags);
        void AddReceipt(Receipt receipt);
    }

    public class DataManager : IDataManager
    {
        private DataTable productsTable;
        private DataTable tagsTable;
        private DataTable unionTable;
        private DataSet dataSet = new DataSet();

        public List<Item> GetItems(params string[] tags)
        {
            List<int> tagIds = new List<int>();
            List<int> itemIds = new List<int>();
            List<Item> ret = new List<Item>();

            // get tag ids
            tags = tags.Distinct().ToArray();
            foreach (string tag in tags)
            {
                DataRow row = tagsTable.Rows.Find(tag);
                tagIds.Add((int)row["tagId"]);
            }

            // get item ids
            foreach (DataRow row in unionTable.Rows)
            {
                foreach(int id in tagIds)
                {
                    if ((int)row["tagId"] == id)
                    {
                        itemIds.Add((int)row["itemId"]);
                        break;
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

        public List<string> GetItemsStrTest(string[] tags)
        {
            return GetItems(tags).Select(i => i.Name).ToList();
        }

        private Item RowToItem(DataRow row)
        {
            int id = (int)row["itemId"];
            string name = (string)row["name"];
            int[] prices = new int[row.ItemArray.Length - 2];
            for (int i = 0; i < prices.Length; i++)
                prices[i] = row[i + 2] != DBNull.Value ? (int)row[i + 2] : 0;

            return new Item(id, name, prices);
        }

        public void InitTestTables()
        {
            CreateDataTable();

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

        public void CreateDataTable()
        {
            productsTable = new DataTable("Items");
            DataColumn columnItemId = productsTable.Columns.Add("itemId", typeof(int));
            columnItemId.AutoIncrement = true;
            columnItemId.AutoIncrementSeed = 1;
            columnItemId.AutoIncrementStep = 1;
            productsTable.PrimaryKey = new DataColumn[] { columnItemId };
            productsTable.Columns.Add("name", typeof(string));
            foreach (string shop in Enum.GetNames(typeof(Shop)))
                productsTable.Columns.Add("price" + shop, typeof(int));

            tagsTable = new DataTable("Tags");
            DataColumn columnTagId = tagsTable.Columns.Add("tagId", typeof(int));
            columnTagId.AutoIncrement = true;
            columnTagId.AutoIncrementSeed = 1;
            columnTagId.AutoIncrementStep = 1;
            tagsTable.PrimaryKey = new DataColumn[] { columnTagId };
            tagsTable.Columns.Add("name", typeof(string));

            unionTable = new DataTable("ItemsTags");
            unionTable.Columns.Add("tagId", typeof(int));
            unionTable.Columns.Add("itemId", typeof(int));
        }

        public void AddItem(Item item)
        {
            List<Item> found = GetItems(item.Tags);
            if (found[0].Name != item.Name)
            {
                // add new entry to database
                DataRow itemRow = productsTable.Rows.Add(
                    null,
                    item.Name,
                    item.Prices[(int)Shop.Maxima],
                    item.Prices[(int)Shop.Norfa],
                    item.Prices[(int)Shop.Rimi],
                    item.Prices[(int)Shop.Iki]);

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
            throw new NotImplementedException();
        }

        public void LoadData()
        {
            dataSet.Clear();
            try
            {
                dataSet.ReadXml("DataTables.xml");
                productsTable = dataSet.Tables["Items"];
                tagsTable = dataSet.Tables["Tags"];
                unionTable = dataSet.Tables["ItemsTags"];
                DataTable customerTable = dataSet.Tables["Customer"];
            }
            catch (FileNotFoundException)
            {                
                CreateDataTable();
                InitTestTables();
            }
        }

        public void SaveData()
        {
            if (dataSet.Tables.Count == 0)
            {
                dataSet.Tables.Add(productsTable);
                dataSet.Tables.Add(tagsTable);
                dataSet.Tables.Add(unionTable);
            }
            dataSet.WriteXml("DataTables.xml");
        }
    }
}
