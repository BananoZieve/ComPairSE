using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPairSE
{
    public partial class HistoryForm : Form
    {
        IDataManager DataManager;
        Form MainForm;
        List<Receipt> receipts;

        public HistoryForm(Form MainForm, IDataManager DataManager)
        {
            InitializeComponent();
            this.DataManager = DataManager;
            this.MainForm = MainForm;
            InitListView();
        }

        private void InitListView()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            this.listView1.Columns.Add("Date", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Price", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Shop", -2, HorizontalAlignment.Left);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            this.receipts = DataManager.GetReceipts();
            if (receipts.Count > 0)
            {
                foreach (Receipt receipt in receipts)
                {
                    this.listView1.Items.Add(new ListViewItem(new[] { receipt.PurchaseTime.ToString(), Util.ToDecimal(receipt.TotalPrice).ToString("C2"), receipt.Shop.ToString() }));
                }
                info.Visible = true;
            }
            else
            {
                info.Visible = false;
            }
        }

        private void HistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatePicker.Visible = true;
            ShowHistory.Visible = true;
        }

        private void ShowHistory_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            this.receipts = DataManager.GetReceipts(DatePicker.Value.Date);

            if (receipts.Count > 0)
            {
                foreach (Receipt receipt in receipts)
                {
                    this.listView1.Items.Add(new ListViewItem(new[] { receipt.PurchaseTime.ToString(), Util.ToDecimal(receipt.TotalPrice).ToString("C2"), receipt.Shop.ToString() }));
                }
                info.Visible = true;
            }
            else
            {
                info.Visible = false;
            }
            DatePicker.Visible = false;
            ShowHistory.Visible = false;
        }

        private void info_Click(object sender, EventArgs e)
        {
                ReceiptForm receiptForm = new ReceiptForm(receipts.ElementAt(listView1.SelectedIndices[0]));
                receiptForm.Show();
        }
    }
}
