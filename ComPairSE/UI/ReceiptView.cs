using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPairSEBack.UI
{
    public partial class ReceiptView : UserControl
    {
        public ReceiptView()
        {
            InitializeComponent();
            maxVisibleRowCount = (this.dgvReceipt.Height - this.dgvReceipt.ColumnHeadersHeight) / this.dgvReceipt.RowTemplate.Height;
        }

        public ReceiptView(Receipt receipt) : this()
        {
            Receipt = receipt;
        }

        private readonly int maxVisibleRowCount;

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
                        dgvReceipt.Rows.Add(item.Name, item.Prices[(int)receipt.ShopEnum].ToPrice().ToString("C2"));
                    tbTotal.Text = receipt.Total.ToPrice().ToString("C2");
                }
            }
        }

        private void ReceiptView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (dgvReceipt.RowCount == 0 || dgvReceipt.RowCount <= maxVisibleRowCount) return;

            int newIndex = dgvReceipt.FirstDisplayedScrollingRowIndex - e.Delta / 120;
            int endScrollIndex = dgvReceipt.RowCount - maxVisibleRowCount;

            if (newIndex < 0)
                dgvReceipt.FirstDisplayedScrollingRowIndex = 0;
            else if (newIndex > endScrollIndex)
                dgvReceipt.FirstDisplayedScrollingRowIndex = endScrollIndex;
            else
                dgvReceipt.FirstDisplayedScrollingRowIndex = newIndex;
        }
    }
}
