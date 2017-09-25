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

    public class LocalDataManager : IDataManager
    {
        private DataTable Items;
        private DataTable Tags;
        private DataTable ItemsTags;

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
                DataRow row = Tags.Rows.Find(tag);
                tagIds.Add((int)row["tagId"]);
            }

            // get item ids
            foreach (DataRow row in ItemsTags.Rows)
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
                DataRow row = Items.Rows.Find(itemId);
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
            Items = new DataTable();
            Tags = new DataTable();
            ItemsTags = new DataTable();

            // HARD-CODE
            Items.Columns.Add("itemId", typeof(int));
            Items.Columns.Add("name", typeof(string));
            foreach (string shop in Enum.GetNames(typeof(Shop)))
                Items.Columns.Add("price" + shop, typeof(int));
            Items.PrimaryKey = new DataColumn[] { Items.Columns["itemId"] };
            Items.Rows.Add(1, "Dvaro Pienas 1l", 1, 3, 10, 52);
            Items.Rows.Add(2, "Rokiskio Pienas 2l", 1, 3, 10, 52);
            Items.Rows.Add(3, "Bandele su varske", 1, 3, 10, 52);
            Items.Rows.Add(4, "Bandele su cinamonu", 1, 3, 10, 52);
            Items.Rows.Add(5, "Dvaro grietine", 1, 3, 10, 52);

            Tags.Columns.Add("tagId", typeof(int));
            Tags.Columns.Add("name", typeof(string));
            Tags.PrimaryKey = new DataColumn[] { Tags.Columns["name"] };
            Tags.Rows.Add(1, "Dvaro");
            Tags.Rows.Add(2, "Pienas");
            Tags.Rows.Add(3, "Rokiskio");
            Tags.Rows.Add(4, "Bandele");
            Tags.Rows.Add(5, "su varske");
            Tags.Rows.Add(6, "su cinamonu");
            Tags.Rows.Add(7, "grietine");

            ItemsTags.Columns.Add("itemId", typeof(int));
            ItemsTags.Columns.Add("tagId", typeof(int));
            ItemsTags.Rows.Add(1,1);
            ItemsTags.Rows.Add(1, 2);
            ItemsTags.Rows.Add(2, 2);
            ItemsTags.Rows.Add(2, 3);
            ItemsTags.Rows.Add(3, 4);
            ItemsTags.Rows.Add(3, 5);
            ItemsTags.Rows.Add(4, 4);
            ItemsTags.Rows.Add(4, 6);
            ItemsTags.Rows.Add(5, 1);
            ItemsTags.Rows.Add(5, 7);
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
