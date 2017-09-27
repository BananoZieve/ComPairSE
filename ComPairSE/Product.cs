﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPairSE
{
    public class Item
    {
        private Item()
        {
            Prices = new int[Enum.GetNames(typeof(Shop)).Length];
        }

        public Item(string name, int price, Shop shop) : this()
        {
            Name = name;
            Prices[(int)shop] = price;
        }

        public Item(string name, int price, Shop shop, string[] tags) : this(name, price, shop)
        {
            Tags = tags;
            Shop = "Maxima";
        }

        public Item(int id, string name, int[] prices)
        {
            Id = id;
            Name = name;
            Prices = prices;
            Shop = "Maxima";
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int[] Prices { get; private set; } // in Euro cents

        public string Shop { get; private set; }

        public string[] Tags { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Id, Name);
        }
    }
}
