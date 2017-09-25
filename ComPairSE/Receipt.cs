using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ComPairSE
{
    public enum Shop
    {
        Maxima,
        Norfa,
        Rimi,
        Iki
    }

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

            // extract from rawData later
            Shop shop = Shop.Maxima;

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
                    itemList.Add(new Item(name, price, shop, tags));
                    tagCount = 0;
                    i++;
                }
                else
                {
                    tagCount++;
                }
            }

            if (itemList.Count > 0)
                receipt = new Receipt(shop, itemList);

            return receipt;
        }

        public static Receipt Create(Shop shop, List<Item> items)
        {
            return new Receipt(shop, items);
        }

        private Receipt()
        {
        }

        private Receipt(Shop shop, List<Item> items) : this()
        {
            Shop = shop;
            Items = items.ToArray();
            TotalPrice = Items.Sum(item => item.Prices[(int)Shop]); // slower than foreach
            PurchaseTime = DateTime.Now;
        }

        public readonly Shop Shop;
        public readonly Item[] Items;
        public readonly DateTime PurchaseTime;
        public readonly int TotalPrice;
    }
}
