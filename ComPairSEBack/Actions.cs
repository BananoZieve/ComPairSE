using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPairSEBack
{
    public class Actions
    {
        IDataManager dataManager;

        public Actions(IDataManager manager)
        {
            dataManager = manager;
            dataManager.LoadData();
        }
        public string[] UploadReceipt(string receiptData)
        {
            Receipt receipt = Receipt.Create(receiptData);
            dataManager.AddReceipt(receipt);
            receipt.Items.ForEach(dataManager.AddItem);
            return new string[] { Util.ObjToString(receipt), ((int)receipt.ShopEnum).ToString() };
        }
    }
}
