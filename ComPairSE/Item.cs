﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPairSE
{
    public class Item : IEquatable<Item>
    {
        private Item()
        {
            Prices = new int[Enum.GetNames(typeof(ShopEnum)).Length];
        }

        public Item(string name, int price, ShopEnum shop) : this()
        {
            Name = name;
            Prices[(int)shop] = price;
        }

        //public Item(string name, int price, ShopEnum shop, string[] tags) : this(name, price, shop)
        //{
        //    Tags = tags;
        //}

        public Item(int id, string name, int[] prices)
        {
            Id = id;
            Name = name;
            Prices = prices;
        }

        public bool Equals(Item other)
        {
            if (this.Name.Equals(other.Name)) return true;
            else return false;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int[] Prices { get; private set; } // in Euro cents

        public string[] Tags { get { return Name.Split(' '); } }

        public override string ToString()
        {
            return string.Format("{0} {1}", Id, Name);
        }

        public string[] GetTags()
        {
            return new string[0];
        }
    }
}
