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
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        public IDataManager DataManager { get; set; }

        private CartPage ReceiptPage { get { return NextPage as CartPage; } }

        private string oldSearch = string.Empty;

        private void AddItem_Click(object sender, EventArgs e)
        {
            if (ReceiptPage != null)
            {
                ItemView itemView = sender as ItemView;
                if (itemView != null)
                    ReceiptPage.AddItem(itemView);
            }
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            if (ReceiptPage != null)
            {
                ItemView itemView = sender as ItemView;
                if (itemView != null)
                    ReceiptPage.RemoveItem(itemView);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text == string.Empty || tbSearch.Text == oldSearch) return;
            oldSearch = tbSearch.Text;
            searchPanel.Controls.Clear();
            List<Item> list = DataManager.GetItems(tbSearch.Text.Split(null));
            foreach (Item item in list)
            {
                ItemView iv = new ItemView(item);
                iv.AddClick += new EventHandler<EventArgs>(AddItem_Click);
                iv.RemoveClick += new EventHandler<EventArgs>(RemoveItem_Click);
                searchPanel.Controls.Add(iv);
            }
        }

        private void SearchPage_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) { tbSearch.Select(); tbSearch.SelectAll(); }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
