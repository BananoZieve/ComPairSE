using System;
using System.Collections.Generic;
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
            ShopEnum shop;
            switch (shopId)
            {
                case "230335113": shop = ShopEnum.Maxima; break;
                case "107783219": shop = ShopEnum.Norfa; break;
                case "237153113": shop = ShopEnum.Rimi; break;
                case "101937219": shop = ShopEnum.Iki; break;
                default: throw new ArgumentException("Unknown shop");
            }
            return GetShop(shop);
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
            //public string ItemPattern => @"^(?<name>.*?)((\n|\r|\r\n)(\s{1,3}(?<unitPrice>\d+,\d{2})\sX\s(?<amount>\d{1,2}(,\d{3})?)\s(vnt\.|pak\.|kg)|(?<extraName>\p{L}+)))?\s+(?<price>-?\d+,\d{2})\s[ABEN]\r$";
            public string ItemPattern => @"^(?<name>.*?)((\n|\r|\r\n)(\s{1,3}(?<unitPrice>\d+,\d{2})\sX\s(?<amount>\d{1,2}(,\d{3})?)\s(vnt\.|pak\.|kg)|(?<extraName>\p{L}+)))?\s+(?<price>-?\d+,\d{2})\s[ABEN9g]\r?$";

            public ShopEnum ShopEnum => ShopEnum.Maxima;
        }

        private class Norfa : IShop
        {
            public string ItemPattern => @"^(?<name>.*?)((?<amount>\d+\.\d{2,3})x(?<unitPrice>\d+\.\d{2}))?\s+(?<price>-?\d+\.\d{2})(M1|EUR)\r$";

            public ShopEnum ShopEnum => ShopEnum.Norfa;
        }

        private class Rimi : IShop
        {
            public string ItemPattern => @"(^\sNuol\.\s(?<price>-\d+,\d{2})\sGalut\.\skaina\s\d+,\d{2}\r$|^(?<name>.*?)((\n|\r|\r\n)(?<extraName>.*?))?\s+(?<price>\d+,\d{2})\s[AE]\r$)";

            public ShopEnum ShopEnum => ShopEnum.Rimi;
        }

        private class Iki : IShop
        {
            public string ItemPattern => throw new NotImplementedException();

            public ShopEnum ShopEnum => throw new NotImplementedException();
        }
    }
}
