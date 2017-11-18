using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPairSE.UI
{
    //[Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            PreviousPage = null;
            NextPage = null;
        }

        public Page(Page previous) : this(previous, null)
        {
        }

        public Page(Page previous, Page next) : this()
        {
            PreviousPage = previous;
            NextPage = next;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return lbPageTitle.Text; }
            set { lbPageTitle.Text = value; }
        }

        protected Button NextButton { get { return btNext; } }
        protected Button PreviousButton { get { return btPrev; } }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue("Next")]
        public string NextText
        {
            get { return btNext.Text; }
            set { btNext.Text = value; }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue("Previous")]
        public string PreviousText
        {
            get { return btPrev.Text; }
            set { btPrev.Text = value; }
        }

        private Page nextPage;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(null)]
        public Page NextPage
        {
            get
            {
                return nextPage;
            }
            set
            {
                btNext.Visible = value != null;
                nextPage = value;
                if (nextPage != null) nextPage.previousPage = this;
            }
        }

        private Page previousPage;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(null)]
        public Page PreviousPage
        {
            get
            {
                return previousPage;
            }
            set
            {
                btPrev.Visible = value != null;
                previousPage = value;
            }
        }

        [Browsable(true)]
        public event EventHandler<EventArgs> NextClick;

        [Browsable(true)]
        public event EventHandler<EventArgs> PreviousClick;

        protected virtual void OnNextButtonClick(EventArgs e)
        {
            if (NextPage != null)
            {
                this.Visible = false;
                NextPage.Visible = true; 
            }
        }

        protected virtual void OnPreviousButtonClick(EventArgs e)
        {
            if (PreviousPage != null)
            {
                this.Visible = false;
                PreviousPage.Visible = true;
            }
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            OnNextButtonClick(e);
            if (NextClick != null)
                NextClick.Invoke(this, e);
        }

        private void btPrev_Click(object sender, EventArgs e)
        {
            OnPreviousButtonClick(e);
            if (PreviousClick != null)
                PreviousClick.Invoke(this, e);
        }
    }

}
