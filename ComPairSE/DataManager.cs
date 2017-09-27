using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace ComPairSE
{
    public interface IDataManager
    {
        void LoadData();
        void SaveData();
        void AddItem(Item product);
        List<Item> GetItems(params string[] tags);
        void AddReceipt(Receipt receipt);
        void CreateDataTable();
    }

    public class DataManager : IDataManager
    {
        private DataTable productsTable;
        private DataTable tagsTable;
        private DataTable unionTable;


        public void AddReceipt(Receipt receipt)
        {
            throw new NotImplementedException();
        }

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
                prices[i] = (int)row[i + 2];

            return new Item(id, name, prices);
        }

        public void InitTestTables()
        {
            productsTable = new DataTable();
            tagsTable = new DataTable();
            unionTable = new DataTable();

            // HARD-CODE
            productsTable.Columns.Add("itemId", typeof(int));
            productsTable.Columns.Add("name", typeof(string));
            foreach (string shop in Enum.GetNames(typeof(Shop)))
                productsTable.Columns.Add("price" + shop, typeof(int));
            productsTable.PrimaryKey = new DataColumn[] { productsTable.Columns["itemId"] };
            productsTable.Rows.Add(1, "Dvaro Pienas 1l", 1, 3, 10, 52);
            productsTable.Rows.Add(2, "Rokiskio Pienas 2l", 1, 3, 10, 52);
            productsTable.Rows.Add(3, "Bandele su varske", 1, 3, 10, 52);
            productsTable.Rows.Add(4, "Bandele su cinamonu", 1, 3, 10, 52);
            productsTable.Rows.Add(5, "Dvaro grietine", 1, 3, 10, 52);

            tagsTable.Columns.Add("tagId", typeof(int));
            tagsTable.Columns.Add("name", typeof(string));
            tagsTable.PrimaryKey = new DataColumn[] { tagsTable.Columns["name"] };
            tagsTable.Rows.Add(1, "Dvaro");
            tagsTable.Rows.Add(2, "Pienas");
            tagsTable.Rows.Add(3, "Rokiskio");
            tagsTable.Rows.Add(4, "Bandele");
            tagsTable.Rows.Add(5, "su varske");
            tagsTable.Rows.Add(6, "su cinamonu");
            tagsTable.Rows.Add(7, "grietine");

            unionTable.Columns.Add("itemId", typeof(int));
            unionTable.Columns.Add("tagId", typeof(int));
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
        private DataSet dataSet = new DataSet();

        public void CreateDataTable()
        {
            productsTable = new DataTable();
            productsTable.Clear();

            DataColumn dc = productsTable.Columns.Add("ProductID", typeof(int));
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
            productsTable.Columns.Add("Name");
            DataColumn column;
            column = productsTable.Columns.Add("Maxima_price", typeof(decimal));
            column.AllowDBNull = true;
            column = productsTable.Columns.Add("IKI_price", typeof(decimal));
            column.AllowDBNull = true;
            productsTable.Columns.Add("Norfa_price", typeof(decimal));
            column.AllowDBNull = true;

            tagsTable = new DataTable();
            DataColumn datac = tagsTable.Columns.Add("TagID", typeof(int));
            datac.AutoIncrement = true;
            datac.AutoIncrementSeed = 1;
            datac.AutoIncrementStep = 1;
            tagsTable.Columns.Add("Tag");

            unionTable = new DataTable();
            unionTable.Columns.Add("TagID", typeof(int));
            unionTable.Columns.Add("ProductID", typeof(int));
        }



        public void AddItem(Item product)
        {
            DataRow productsTableRow = productsTable.NewRow();
            productsTableRow["Name"] = product.Name;
         //   switch (product.Shop)
          //  {
           //     case "Maxima": productsTableRow["Maxima_price"] = product.PriceC; break;
            //    case "IKI": productsTableRow["IKI_price"] = product.PriceC; break;
             //   case "Norfa": productsTableRow["Norfa_price"] = product.PriceC; break;       
         //   }
            productsTable.Rows.Add(productsTableRow);

            DataRow lastRow = productsTable.Rows[productsTable.Rows.Count - 1];
            int currentProductID = (int)lastRow["ProductID"];

            foreach (String tag in product.Tags)
            {
                DataRow tagsTableRow = tagsTable.NewRow();
                tagsTableRow["Tag"] = tag;
                tagsTable.Rows.Add(tagsTableRow);
                DataRow unionTableRow = unionTable.NewRow();
                unionTableRow["ProductID"] = currentProductID;
                unionTableRow["TagID"] = (int)(tagsTable.Rows[tagsTable.Rows.Count - 1]["TagID"]);
                unionTable.Rows.Add(unionTableRow);
            }
        }

        public void LoadData()
        {

            dataSet.Clear();
            dataSet.ReadXml("DataTables.xml");
            productsTable = dataSet.Tables["productsTable"];
            tagsTable = dataSet.Tables["tagsTable"];
            unionTable = dataSet.Tables["unionTable"];

            DataTable customerTable = dataSet.Tables["Customer"];
        }

        public void SaveData()
        {


            dataSet.Clear();
            if (productsTable != null)
            {
                dataSet.Tables.Add(productsTable);
                dataSet.Tables.Add(tagsTable);
                dataSet.Tables.Add(unionTable);
            }
                dataSet.WriteXml("DataTables.xml");
        }
    }
}
