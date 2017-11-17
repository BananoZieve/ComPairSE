using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPairSE
{
    public enum ShopEnum
    {
        Maxima,
        Norfa,
        Rimi,
        Iki
    }

    public interface IShop
    {
        string ItemPattern { get; }
        ShopEnum ShopEnum { get; }
    }

    public static class Shop
    {
        public static IShop GetShop(string shopId)
        {  
            //finds all VAT codes
                            ShopEnum shop;
            var ShopCodes = Properties.Settings.Default.Properties.OfType<SettingsProperty>()
                  .Where(key => key.Name.EndsWith("VAT"))
                  .Select(key => new { name = key.Name.Split('_')[0], value = Properties.Settings.Default[key.Name].ToString() })
                  .ToArray();

            //Looks for the shopID match and finds to which shop it belongs
            //returns shop's Enum -> shop's object
             foreach (var i in ShopCodes)
             {
                 if (i.value == shopId)
                 {
                     shop = (ShopEnum)System.Enum.Parse(typeof(ShopEnum), i.name);
                     return GetShop(shop);
                 }
             }

             throw new ArgumentException("Unknown shop");

        }

        public static IShop GetShop(ShopEnum shop)
        {
            switch (shop)
            {
                case ShopEnum.Maxima: return new Maxima();
                case ShopEnum.Norfa: return new Norfa();
                case ShopEnum.Rimi: return new Rimi();
                case ShopEnum.Iki: return new Iki();
                default: throw new ArgumentException(string.Format("No matching shop class ({0})", shop.ToString()));
            }
        }

        private class Maxima : IShop
        {
            public string ItemPattern { get { return @"^(?<name>.*?)((\n|\r|\r\n)(\s{1,3}(?<unitPrice>\d+,\d{2})\sX\s(?<amount>\d{1,2}(,\d{3})?)\s(vnt\.|pak\.|kg)|(?<extraName>\p{L}+)))?\s+(?<price>-?\d+,\d{2})\s[ABEN9g]\r?$"; } }

            public ShopEnum ShopEnum { get { return ShopEnum.Maxima; } }
        }

        private class Norfa : IShop
        {
            public string ItemPattern { get { return @"^(?<name>.*?)((?<amount>\d+\.\d{2,3})x(?<unitPrice>\d+\.\d{2}))?\s+(?<price>-?\d+\.\d{2})(M1|EUR)\r$"; } }

            public ShopEnum ShopEnum { get { return ShopEnum.Norfa; } }
        }

        private class Rimi : IShop
        {
            public string ItemPattern { get { return @"(^\sNuol\.\s(?<price>-\d+,\d{2})\sGalut\.\skaina\s\d+,\d{2}\r$|^(?<name>.*?)((\n|\r|\r\n)(?<extraName>.*?))?\s+(?<price>\d+,\d{2})\s[AE]\r$)"; } }

            public ShopEnum ShopEnum { get { return ShopEnum.Rimi; } }
        }

        private class Iki : IShop
        {
            public string ItemPattern { get { throw new NotImplementedException(); } }

            public ShopEnum ShopEnum { get { throw new NotImplementedException(); } }
        }
    }
}
