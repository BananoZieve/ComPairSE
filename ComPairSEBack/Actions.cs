using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPairSE
{
    public class Actions
    {
        IDataManager dataManager;

        public Actions(IDataManager manager)
        {
            dataManager = manager;
        }
        public string UploadReceipt(string receiptData)
        {
            Receipt receipt = Receipt.Create(receiptData);
            dataManager.AddReceipt(receipt);
            receipt.Items.ForEach(dataManager.AddItem);
            return Util.ObjToString(receipt);
        }

        public string GetReceiptsHistory()
        {
           return Util.ObjToString(dataManager.GetReceipts());
        }

        public void SaveToFile()
        {
            dataManager.SaveData();
        }

        public void LoadFromFile()
        {
            dataManager.LoadData();
        }

        public string GetReceiptByID(int id)
        {
            return Util.ObjToString(dataManager.GetReceiptByID(id));
        }

        public string GetReceiptsByDate(DateTime date)
        {
            return Util.ObjToString(dataManager.GetReceipts(date));
        }
    }
}
