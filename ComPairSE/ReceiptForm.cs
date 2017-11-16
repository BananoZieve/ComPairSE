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
    public partial class ReceiptForm : Form
    {
        public ReceiptForm()
        {
            InitializeComponent();
            dgvReceipt.AutoGenerateColumns = false;
            dgvReceipt.Width = ClientRectangle.Width - 2 * dgvReceipt.Left;
            columnPrice.Width = dgvReceipt.Width * 4 / 15;
            columnItem.Width = dgvReceipt.Width - columnPrice.Width - 3;
            tbTotal.Left = ClientRectangle.Width - dgvReceipt.Left - columnPrice.Width - 2;
            tbTotal.Width = columnPrice.Width + 2;
            lbTotal.Left = tbTotal.Left - lbTotal.Width - lbTotal.Padding.Left;
            this.MouseWheel += this.ReceiptForm_MouseWheel;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public ReceiptForm(JObject receipt, string shop) : this()
        {
              JToken token = receipt;
              if (receipt.SelectToken("Items") != null)
                  foreach ( JToken item in receipt.SelectToken("Items"))
                 {
                      dgvReceipt.Rows.Add(item.SelectToken("Name"), item.SelectToken("Prices")[int.Parse(shop)]);
                 }
            tbTotal.Text = (int.Parse((String)receipt.SelectToken("Total"))).ToPrice().ToString("C2");

        }

        private void ReceiptForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (dgvReceipt.Rows.Count == 0) return;
            int newIndex = dgvReceipt.FirstDisplayedScrollingRowIndex - e.Delta / 120;
            if (newIndex < 0)
                dgvReceipt.FirstDisplayedScrollingRowIndex = 0;
            else if (newIndex > dgvReceipt.RowCount - 9)
                dgvReceipt.FirstDisplayedScrollingRowIndex = Math.Max(dgvReceipt.RowCount - 9,0);
            else
                dgvReceipt.FirstDisplayedScrollingRowIndex = newIndex;
        }
    }
}
