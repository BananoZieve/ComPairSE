using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComPairSE;

namespace UnitTestCSE
{
    [TestClass]
    public class DataManagerTests
    {
        private DataManager DataManager = new DataManager();

        public DataManagerTests()
        {
            DataManager.CreateDataTables();
            DataManager.InitDataTables();
            DataManager.InitTestTables();
        }

        [TestMethod]
        public void GetItems_Pienas_CountIs2()
        {
            var l = DataManager.GetItemsStrTest(new string[] { "Pienas" });
            Assert.AreEqual(l[0], "Dvaro Pienas 1l");
            Assert.AreEqual(l[1], "Rokiskio Pienas 2l");
            Assert.AreEqual(2, l.Count);

        }
        [TestMethod]
        public void GetItems_DvaroPienas_CountIs1()
        {
            var l = DataManager.GetItemsStrTest(new string[] { "Dvaro", "Pienas" });
            Assert.AreEqual(l[0], "Dvaro Pienas 1l");
            Assert.AreEqual(3, l.Count);

        }
        [TestMethod]
        public void GetItems_Bandele_CountIs2()
        {
            var l = DataManager.GetItemsStrTest(new string[] { "Bandele" });
            Assert.AreEqual(l[0], "Bandele su varske");
            Assert.AreEqual(l[1], "Bandele su cinamonu");
            Assert.AreEqual(2, l.Count);

        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
