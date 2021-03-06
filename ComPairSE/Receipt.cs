﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ComPairSE
{
    public class Receipt : IComparable<Receipt>, IComparable
    {
        /// <summary>
        /// Create a receipt from a raw string
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public static Receipt Create(string rawData)
        {
            IShop shop;
            Match match;
            List<Item> itemList = new List<Item>();

            match = Regex.Match(rawData, @"P[VU][MNH] mok[eė]tojo kodas:? L[TIl](\d{9})");
            if (match.Success)
                shop = Shop.GetShop(match.Groups[1].Value);
            else
                throw new ArgumentException("No shop ID");

            match = Regex.Match(rawData, shop.ItemPattern, RegexOptions.Multiline);
            while (match.Success)
            {
                string name, extraName;
                int price, unitPrice;
                decimal amount;

                name = match.Groups["name"].Value;
                extraName = match.Groups["extraName"].Value;
                if (extraName != string.Empty)
                    name += " " + extraName;

                price = int.Parse(match.Groups["price"].Value.RemoveDecimalMark());
                unitPrice = match.Groups["unitPrice"].Value != string.Empty ? int.Parse(match.Groups["unitPrice"].Value.RemoveDecimalMark()) : price;
                if (name == string.Empty && price < 0)
                    name = "Nuolaida";

                if (!decimal.TryParse(match.Groups["amount"].Value, out amount))
                    amount = 1;

                itemList.Add(new Item(name, price, shop.ShopEnum));
                match = match.NextMatch();
            }

            return new Receipt(shop.ShopEnum, itemList);
        }

        public static Receipt Create(ShopEnum shop, List<Item> items)
        {
            return new Receipt(shop, items);
        }

        public static Receipt Create(ShopEnum shop, List<Item> items, DateTime dateTime)
        {
            return new Receipt(shop, items, dateTime);
        }

        public static Receipt Create(ShopEnum shop, List<Item> items, DateTime dateTime, int total)
        {
            return new Receipt(shop, items, dateTime, total);
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
                    int r1Count = this.Items.Count(item => item.Prices[(int)this.ShopEnum] > 0);
                    int r2Count = other.Items.Count(item => item.Prices[(int)other.ShopEnum] > 0);

                    if (r1Count == r2Count)
                        return this.Total - other.Total;
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

        private Receipt(ShopEnum shop, List<Item> items) : this()
        {
            ShopEnum = shop;
            Items = items;
            Total = Items.Sum(item => item.Prices[(int)ShopEnum]); // slower than foreach
            PurchaseTime = DateTime.Now;
        }

        private Receipt(ShopEnum shop, List<Item> items, DateTime dateTime) : this(shop, items)
        {
            PurchaseTime = dateTime;
        }

        private Receipt(ShopEnum shop, List<Item> items, DateTime dateTime, int total) : this(shop, items, dateTime)
        {
            Total = total;
        }

        public readonly ShopEnum ShopEnum;
        public readonly List<Item> Items;
        public readonly DateTime PurchaseTime;
        public readonly int Total;
    }
}
