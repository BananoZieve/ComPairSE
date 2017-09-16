using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPairSE
{
    public interface IDataManager
    {
        void LoadData();
        void SaveData();
        void AddItem(Item product);
        List<Item> GetItems(params string[] tags);
        void AddReceipt(Receipt receipt);
    }

    //public class DataManager : IDataManager
    //{
    //}
}
