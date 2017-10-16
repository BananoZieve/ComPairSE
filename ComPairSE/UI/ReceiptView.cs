using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPairSE.UI
{
    public partial class ReceiptView : UserControl
    {
        public ReceiptView()
        {
            InitializeComponent();
        }

        public ReceiptView(Receipt receipt) : this()
        {
            Receipt = receipt;
        }

        private Receipt receipt;
        public Receipt Receipt
        {
            get { return receipt; }
            set
            {
                if (value != null)
                {
                    receipt = value;
                    lbShop.Text = receipt.ShopEnum.ToString();
                    dgvReceipt.Rows.Clear();
                    dgvReceipt.Refresh();
                    foreach (Item item in receipt.Items)
                        dgvReceipt.Rows.Add(item.Name, item.Prices[(int)receipt.ShopEnum].ToDecimal().ToString("C2"));
                    textBox1.Text = receipt.TotalPrice.ToDecimal().ToString("C2");                    
                }
            }
        }

        private void ReceiptView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (dgvReceipt.Rows.Count == 0) return;
            int newIndex = dgvReceipt.FirstDisplayedScrollingRowIndex - e.Delta / 120;
            if (newIndex < 0)
                dgvReceipt.FirstDisplayedScrollingRowIndex = 0;
            else if (newIndex > dgvReceipt.RowCount - 9)
                dgvReceipt.FirstDisplayedScrollingRowIndex = Math.Max(dgvReceipt.RowCount - 9, 0);
            else
                dgvReceipt.FirstDisplayedScrollingRowIndex = newIndex;
        }
    }
}
