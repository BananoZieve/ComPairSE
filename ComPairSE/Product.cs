using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPairSE
{
    public class Item
    {
        public Item(string name, int price, string[] tags) : this(name, price)
        {
            Tags = tags;
        }

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }


        public string Name { get; private set; }

        public int Price { get; private set; } // in Euro cents

        public decimal PriceC { get { return Price / 100m; } }

        public string[] Tags { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1:C2}", Name, PriceC);
        }
    }
}
