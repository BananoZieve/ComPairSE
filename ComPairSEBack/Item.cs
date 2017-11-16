using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPairSEBack
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

        public Item(string name, int[] prices, int id = 0)
        {
            Id = id;
            Name = name;
            Prices = prices;
        }

        public bool Equals(Item other)
        {
            if (this.Id != 0 && other.Id != 0) return this.Id == other.Id;
            else return this.Name.Equals(other.Name);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int[] Prices { get; set; } // in Euro cents

        private string[] tags;
        public string[] Tags
        {
            get
            {
                if (tags == null)
                    tags = GetTags();
                return tags;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Id, Name);
        }

        public string[] GetTags()
        {
            //if (Id != 0)
            //{ }
            //else
            //{
            List<string> ret = new List<string>();
            string[] split = Name.Split(' ');
            string prielinksnis = string.Empty;
            bool prev = false;
            foreach (string rawTag in split)
            {
                string tag = rawTag.ToLower();
                if (prev)
                {
                    tag = prielinksnis + " " + tag;
                    prev = false;
                }
                else
                {
                    if (tag == "su") { prev = true; prielinksnis = tag; continue; }
                }
                // skip additional tags for now
                if (tag.EndsWith(",")) { ret.Add(tag.TrimEnd(',')); break; }
                else { ret.Add(tag); }
            }
            return ret.ToArray();

            //}
        }
    }
}
