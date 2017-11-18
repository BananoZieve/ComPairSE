using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        string CreateReceipt(string receiptData);

        [OperationContract]
        string getAllReceiptsFromHistory();

        [OperationContract]
        void LoadDataFromFile();

        [OperationContract]
        void SaveDataToFile();

        [OperationContract]
        string GetReceiptByID(int id);

        [OperationContract]
        string GetReceiptsByDate(DateTime date);

    }
}
