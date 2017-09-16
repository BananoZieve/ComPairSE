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
            string pattern = @".+\r?\n?.+\d{2}\s[ABEN]"; // might need individual patterns for different shops
            foreach (Match m in Regex.Matches(rawData, pattern))
            {
                string[] split = m.Value.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

                List<string> tagsList = new List<string>();

                for (int i = 0; i < split.Length - 2; i++)
                    if (split[i].Length > 1)
                        tagsList.Add(split[i].Trim(','));

                int price;

                if (int.TryParse(split[split.Length-2].Replace(",", string.Empty), out price))
                {
                    string[] tags = tagsList.ToArray();
                    string name = string.Join(" ", tags);
                    itemList.Add(new Item(name, price, tags));
                }
            }

            if (itemList.Count > 0)
                receipt = new Receipt(itemList);

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
