using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPairSEBack
{
    public partial class HistoryForm : Form
    {
        Form MainForm;
        ComPairSE.FirstService.DataServiceClient dataService;
        List<JToken> response;

        public HistoryForm(Form MainForm)
        {
            InitializeComponent();
            this.DatePicker.Value = DateTime.Now;
            this.MainForm = MainForm;
            dataService = new ComPairSE.FirstService.DataServiceClient();
            InitListView();
            response = new List<JToken>();
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
            JToken token = JArray.Parse(dataService.getAllReceiptsFromHistory());
            
            if (token != null)
            {
                foreach (JToken t in token)
                {
                    response.Add(t);
                    this.listView1.Items.Add(new ListViewItem(new[] { (string)t.SelectToken("Date"), Util.ToPrice(int.Parse((t.SelectToken("Price").ToString()))).ToString("C2"), (string)t.SelectToken("Shop") }));
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
            JToken token = JArray.Parse(dataService.GetReceiptsByDate(DatePicker.Value.Date));

            if (token != null)
            {
                foreach (JToken t in token)
                {
                    response.Add(t);
                    this.listView1.Items.Add(new ListViewItem(new[] { (string)t.SelectToken("Date"), Util.ToPrice(int.Parse((t.SelectToken("Price").ToString()))).ToString("C2"), (string)t.SelectToken("Shop") }));
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
            
            if (listView1.SelectedItems.Count > 0)
            {
                var receipt = dataService.GetReceiptByID((int)(response.ElementAt(listView1.SelectedIndices[0])).SelectToken("ID"));
                ReceiptForm receiptForm = new ReceiptForm(JObject.Parse(receipt));
                receiptForm.Show();
            }
            else
            {
                toolTip.Show("Select an item first", listView1, 3000);
            }
            
            
        }
    }
}
