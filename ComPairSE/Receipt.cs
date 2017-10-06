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

    public class Receipt : IComparable<Receipt>, IComparable
    {
        /// <summary>
        /// Create a receipt from a raw string
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public static Receipt Create(string rawData)
        {
            Shop shop = Shop.Maxima; // Shop.Undefined?
            List<Item> itemList = new List<Item>();
            Match match;
            string itemPattern = string.Empty;
            match = Regex.Match(rawData, @"PVM mok[eė]tojo kodas (LT\d{9})");
            if (match.Success)
            {
                switch (match.Groups[1].Value)
                {
                    case "LT230335113":
                        shop = Shop.Maxima;
                        itemPattern = @"^(?<name>.*?)((\n|\r|\r\n)(\s{1,3}(?<unitPrice>\d+,\d{2})\sX\s(?<amount>\d{1,2}(,\d{3})?)\s(vnt\.|pak\.|kg)|(?<extraName>\p{L}+)))?\s+(?<price>-?\d+,\d{2})\s[ABEN]\r$";
                        break;
                    case "LT107783219":
                        shop = Shop.Norfa; break;
                    case "LT237153113":
                        shop = Shop.Rimi; break;
                    case "LT101937219":
                        shop = Shop.Iki; break;
                    default:
                         throw new ArgumentException("Unknown shop");
                }
            }

            Match itemMatch = Regex.Match(rawData, itemPattern, RegexOptions.Multiline);
            while (itemMatch.Success)
            {
                string extraName = itemMatch.Groups["extraName"].Value;
                string name = itemMatch.Groups["name"].Value;
                if (extraName != string.Empty)
                    name += " " + extraName;
                int price = int.Parse(itemMatch.Groups["price"].Value.Replace(",", ""));
                int unitPrice = itemMatch.Groups["unitPrice"].Value != string.Empty ? int.Parse(itemMatch.Groups["unitPrice"].Value.Replace(",","")) : price;
                decimal amount;
                if (!decimal.TryParse(itemMatch.Groups["amount"].Value, out amount))
                    amount = 1;
                itemList.Add(new Item(name, price, shop));
                itemMatch = itemMatch.NextMatch();
            }

            return new Receipt(shop, itemList);
        }

        public static Receipt Create(Shop shop, List<Item> items)
        {
            return new Receipt(shop, items);
        }

        public int CompareTo(object obj)
        {
            if (obj != null && !(obj is Receipt))
                throw new ArgumentException();

            return CompareTo(obj as Receipt);
        }

        public int CompareTo(Receipt other)
        {
            if (other != null)
            {
                if (this.Items != null && other.Items != null)
                {
                    // assume ReferenceEquals(this.Items, other.Items) == true

                    // number of non-zero priced (present in the shop) items
                    int r1Count = this.Items.Count(item => item.Prices[(int)this.Shop] > 0);
                    int r2Count = other.Items.Count(item => item.Prices[(int)other.Shop] > 0);

                    if (r1Count == r2Count)
                        return this.TotalPrice - other.TotalPrice;
                    else
                        return r2Count - r1Count;
                }
                else
                {
                    // special cases
                    if (this.Items == null && other.Items == null)
                        return 0;
                    else
                        return this.Items != null ? -1 : 1;
                }

            }
            else
            {
                return -1; // if other is null reference, this instance is "smaller" (better)
            }
        }

        private Receipt()
        {
        }

        private Receipt(Shop shop, List<Item> items) : this()
        {
            Shop = shop;
            Items = items;
            TotalPrice = Items.Sum(item => item.Prices[(int)Shop]); // slower than foreach
            PurchaseTime = DateTime.Now;
        }

        public readonly Shop Shop;
        public readonly List<Item> Items;
        public readonly DateTime PurchaseTime;
        public readonly int TotalPrice;
    }
}
