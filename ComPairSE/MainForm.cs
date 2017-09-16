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
    public partial class MainForm : Form
    {
        private const int DEFAULT_PAD = 12;

        public MainForm()
        {
            InitializeComponent();
            this.Height -= btRnd.Bottom + 12 - ClientRectangle.Height;
        }

        private void btRnd_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<Item> list = new List<Item>();
            for (int i = 1; i <= rnd.Next(8,25); i++)
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
    }
}
