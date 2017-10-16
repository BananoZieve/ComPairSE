using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace ComPairSE.UI
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }
        
        public ScanPage ScanPage { get; set; }

        public SearchPage SearchPage { get; set; }

        public Page BrowsePage { get; set; }

        private void btScan_Click(object sender, EventArgs e)
        {
            if (ScanPage != null) { ScanPage.Visible = true; this.Visible = false; }
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            if (SearchPage != null) { SearchPage.Visible = true; this.Visible = false; }
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            if (BrowsePage != null) { BrowsePage.Visible = true; this.Visible = false; }
        }
    }
}
