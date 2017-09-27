using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPairSE
{
    public partial class MainForm : Form
    {
        private const int DEFAULT_PAD = 12;
        IDataManager DataManager;

        public MainForm()
        {
            InitializeComponent();
            tbInput.Width = this.ClientRectangle.Width - 2 * tbInput.Left;
            DataManager = new DataManager();
        }

        private void btRnd_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<Item> list = new List<Item>();
            for (int i = 1; i <= rnd.Next(12,25); i++)
                list.Add(new Item(i.ToString(), rnd.Next(20)*100 + rnd.Next(2)*50 + 49));
            Receipt receipt = Receipt.Create(list);
            ReceiptForm receiptForm = new ReceiptForm(receipt);
            receiptForm.Show();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            Receipt receipt = Receipt.Create(tbInput.Text);
            ReceiptForm receiptForm = new ReceiptForm(receipt);
            receiptForm.Show();
        }

        private void button_SearchItemsByTag_Click(object sender, EventArgs e)
        {
            Receipt receipt = Receipt.Create(tbInput.Text);
            SearchByTagForm searchByTagForm = new SearchByTagForm();
            searchByTagForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                DataManager.LoadData();
            }
            catch (FileNotFoundException exc)
            {
                DataManager.CreateDataTable();
            }
        }

        private void MainForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DataManager.SaveData();
        }
    }
}
