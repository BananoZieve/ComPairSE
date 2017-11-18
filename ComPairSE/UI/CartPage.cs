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
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();
            idList = new List<int>();
        }

        private List<int> idList;

        public void AddItem(ItemView itemView)
        {
            if (itemView != null)
            {
                ItemView[] q = receiptPanel.Controls.OfType<ItemView>().Where(i => i.Item.Id == itemView.Item.Id).ToArray();
                if (q.Length == 1) { q[0].Amount++; itemView.Dispose(); }
                else receiptPanel.Controls.Add(itemView);

                //if (idList.Contains(itemView.Item.Id)) { }
            }
        }

        public void RemoveItem(ItemView itemView)
        {
            if (itemView != null)
            {
                receiptPanel.Controls.Remove(itemView);
            }
        }
    }
}
