using ComPairSEBack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IDataService
    {
        Actions action = new Actions(new DataManager());

        public string[] CreateReceipt(string receiptData)
        {
            return action.UploadReceipt(receiptData);

        }

        public string Test(string hey)
        {
            return ("laaaaabaaaas!");
        }
    }
}
