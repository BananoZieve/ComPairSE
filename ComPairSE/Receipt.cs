using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ComPairSE
{
    public class Receipt // : IComparable?
    {
        /// <summary>
        /// Create a receipt from a raw string
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public static Receipt Create(string rawData)
        {
            Receipt receipt = new Receipt();

            List<Item> itemList = new List<Item>(); ;
            string[] rawDataSplit = rawData.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            int tagCount = 0;
            for (int i = 0; i < rawDataSplit.Length-1; i++)
            {
                if (Regex.IsMatch(rawDataSplit[i], @"\d+,\d{2}") && Regex.IsMatch(rawDataSplit[i+1], @"[ABEN]"))
                {
                    string[] tags = new string[tagCount];
                    Array.Copy(rawDataSplit, i-  tagCount, tags, 0, tagCount);
                    string name = string.Join(" ", tags);
                    int price = int.Parse(rawDataSplit[i].Replace(",", string.Empty));
                    itemList.Add(new Item(name, price, tags));
                    tagCount = 0;
                    i++;
                }
                else
                {
                    tagCount++;
                }
            }


            if (itemList.Count > 0)
            {
                receipt = new Receipt(itemList);
            }

            return receipt;
        }

        public static Receipt Create(List<Item> items)
        {
            return new Receipt(items);
        }

        public static Receipt Create(List<Item> items, string shopName)
        {
            return new Receipt(items, shopName);
        }

        private Receipt()
        {
        }

        private Receipt(List<Item> items) : this()
        {
            Items = items.ToArray();
            TotalPrice = Items.Sum(item => item.Price); // slower than foreach
            PurchaseTime = DateTime.Now;
        }

        private Receipt(List<Item> items, string shopName) : this(items)
        {
            ShopName = shopName;
        }

        public readonly Item[] Items;
        public readonly DateTime PurchaseTime;
        public readonly string ShopName;
        public readonly int TotalPrice;
    }
}
