using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

        public void AddItem(Item product)
        {
            throw new NotImplementedException();
        }

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
            unionTable.Rows.Add(1,1);
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

        public void LoadData()
        {
            throw new NotImplementedException();
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }
    }
}
