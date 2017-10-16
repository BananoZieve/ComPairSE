using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPairSE
{
    public partial class ItemView : UserControl
    {
        public ItemView()
        {
            InitializeComponent();
        }

        public ItemView(Item item) : this()
        {
            Item = item;
            lbItemName.Text = item.Name;
        }

        public Item Item;
        public decimal Amount;

        [Browsable(true)]
        public event EventHandler<EventArgs> AddClick;

        [Browsable(true)]
        public event EventHandler<EventArgs> RemoveClick;

        protected virtual void OnAddClicked(EventArgs e)
        {
            btAdd.Enabled = btAdd.Visible = false;
            btRemove.Enabled = btRemove.Visible = true;
        }

        protected virtual void OnRemoveClicked(EventArgs e)
        {
            btRemove.Enabled = btRemove.Visible = false;
            btAdd.Enabled = btAdd.Visible = true;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            OnAddClicked(e);
            if (AddClick != null)
                AddClick.Invoke(this, e);
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            OnRemoveClicked(e);
            if (RemoveClick != null)
                RemoveClick.Invoke(this, e);
        }
    }
}
