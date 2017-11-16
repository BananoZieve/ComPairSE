using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComPairSEBack;
using System.Linq;

namespace UnitTestCSE
{
    [TestClass]
    public class DataManagerTests
    {
        private IDataManager DataManager = new DemoDataManager();

        public DataManagerTests()
        {
            DataManager.LoadData();
        }

        [TestMethod]
        public void ItemSearch_GetItems_Pienas()
        {
            var l = DataManager.GetItems("Pienas").Select(item => item.Name).ToList();
            Assert.AreEqual(l[0], "Dvaro Pienas 1l");
            Assert.AreEqual(l[1], "Rokiskio Pienas 2l");
            Assert.AreEqual(2, l.Count);

        }
        [TestMethod]
        public void ItemSearch_GetItems_DvaroPienas()
        {
            var l = DataManager.GetItems("Dvaro", "Pienas").Select(item => item.Name).ToList();
            Assert.AreEqual(l[0], "Dvaro Pienas 1l");
            Assert.AreEqual(3, l.Count);

        }
        [TestMethod]
        public void ItemSearch_GetItems_Bandele()
        {
            var l = DataManager.GetItems("Bandele").Select(item => item.Name).ToList();
            Assert.AreEqual(l[0], "Bandele su varske");
            Assert.AreEqual(l[1], "Bandele su cinamonu");
            Assert.AreEqual(2, l.Count);

        }
    }

    [TestClass]
    public class ReceiptTests
    {
        private IDataManager DataManager = new DemoDataManager();

        public ReceiptTests()
        {
            DataManager.LoadData();
        }
        
        [TestMethod]
        public void CompareTo_ReceipList_Sort()
        {
            var itemList = DataManager.GetItems("Dvaro", "Pienas");
            var receiptList = new System.Collections.Generic.List<Receipt>()
            {
                Receipt.Create(ShopEnum.Iki, itemList),
                Receipt.Create(ShopEnum.Norfa, itemList),
                Receipt.Create(ShopEnum.Maxima, itemList),
                Receipt.Create(ShopEnum.Rimi, itemList)
            };
            receiptList.Sort();
            Assert.AreEqual(ShopEnum.Maxima, receiptList[0].ShopEnum);
            Assert.AreEqual(ShopEnum.Norfa, receiptList[1].ShopEnum);
            Assert.AreEqual(ShopEnum.Rimi, receiptList[2].ShopEnum);
            Assert.AreEqual(ShopEnum.Iki, receiptList[3].ShopEnum);
        }
    }

    [TestClass]
    public class ReceiptHistoryTests
    {
        private IDataManager DataManager = new DemoDataManager();

        private System.Collections.Generic.List<Receipt> CreateReceipts()
        {
            DataManager.LoadData();

            System.Collections.Generic.List<Item> itemList = new System.Collections.Generic.List<Item>() { new Item("Pienas", 80, ShopEnum.Norfa) };
            System.Collections.Generic.List<Receipt> receiptList = new System.Collections.Generic.List<Receipt>()
            {
            Receipt.Create(ShopEnum.Norfa, itemList),
            Receipt.Create(ShopEnum.Norfa, itemList, new DateTime(2000, 10, 10), 80)
            };

            return receiptList;
    }



        [TestMethod]
        public void GetReceipts()
        {
            System.Collections.Generic.List<Receipt> receiptList = CreateReceipts();
            DataManager.AddReceipt(receiptList[0]);
            Assert.IsNotNull(DataManager.GetReceipts());
        }

        [TestMethod]
        public void GetReceiptsByDate()
        {
            System.Collections.Generic.List<Receipt> receiptList = CreateReceipts();
            DataManager.AddReceipt(receiptList[0]);
            Assert.IsNotNull(DataManager.GetReceipts(DateTime.Now));
            Assert.IsNotNull(DataManager.GetReceipts(new DateTime(2000,10,10)));
        }

    }
}
