using System;
using System.Collections.Generic;
using System.Data;
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

    public class DataManager : IDataManager
    {
        static DataTable productsTable;
        static DataTable tagsTable;
        static DataTable unionTable;
        static DataSet dataSet = new DataSet();

        public void CreateDataTable()
        {
            productsTable = new DataTable();
            productsTable.Clear();

            DataColumn dc = productsTable.Columns.Add("ProductID", typeof(int));
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
            productsTable.Columns.Add("Name");
            DataColumn column;
            column = productsTable.Columns.Add("Maxima_price", typeof(decimal));
            column.AllowDBNull = true;
            column = productsTable.Columns.Add("IKI_price", typeof(decimal));
            column.AllowDBNull = true;
            productsTable.Columns.Add("Norfa_price", typeof(decimal));
            column.AllowDBNull = true;

            tagsTable = new DataTable();
            DataColumn datac = tagsTable.Columns.Add("TagID", typeof(int));
            datac.AutoIncrement = true;
            datac.AutoIncrementSeed = 1;
            datac.AutoIncrementStep = 1;
            tagsTable.Columns.Add("Tag");

            unionTable = new DataTable();
            unionTable.Columns.Add("TagID", typeof(int));
            unionTable.Columns.Add("ProductID", typeof(int));
        }



        public void AddItem(Item product)
        {
            DataRow productsTableRow = productsTable.NewRow();
            productsTableRow["Name"] = product.Name;
            switch (product.Shop)
            {
                case "Maxima": productsTableRow["Maxima_price"] = product.PriceC; break;
                case "IKI": productsTableRow["IKI_price"] = product.PriceC; break;
                case "Norfa": productsTableRow["Norfa_price"] = product.PriceC; break;       
            }
            productsTable.Rows.Add(productsTableRow);

            DataRow lastRow = productsTable.Rows[productsTable.Rows.Count - 1];
            int currentProductID = (int)lastRow["ProductID"];

            foreach (String tag in product.Tags)
            {
                DataRow tagsTableRow = tagsTable.NewRow();
                tagsTableRow["Tag"] = tag;
                tagsTable.Rows.Add(tagsTableRow);
                DataRow unionTableRow = unionTable.NewRow();
                unionTableRow["ProductID"] = currentProductID;
                unionTableRow["TagID"] = (int)(tagsTable.Rows[tagsTable.Rows.Count - 1]["TagID"]);
                unionTable.Rows.Add(unionTableRow);
            }
        }

        public void AddReceipt(Receipt receipt)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetItems(params string[] tags)
        {
            throw new NotImplementedException();
        }

        public void LoadData()
        {
            dataSet.Clear();
            dataSet.ReadXml("DataTables.xml");
            productsTable = dataSet.Tables["productsTable"];
            tagsTable = dataSet.Tables["tagsTable"];
            unionTable = dataSet.Tables["unionTable"];

            DataTable customerTable = dataSet.Tables["Customer"];
        }

        public void SaveData()
        {
            dataSet.Clear();
            dataSet.Tables.Add(productsTable);
            dataSet.Tables.Add(tagsTable);
            dataSet.Tables.Add(unionTable);
           
            dataSet.WriteXml("DataTables.xml");
        }
    }
}
