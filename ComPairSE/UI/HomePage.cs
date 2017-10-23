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
    //[Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public event EventHandler ScanClick
        {
            add { btScan.Click += value; }
            remove { btScan.Click -= value; }
        }

        public event EventHandler SearchClick
        {
            add { btCreate.Click += value; }
            remove { btCreate.Click -= value; }
        }

        public event EventHandler BrowseClick
        {
            add { btBrowse.Click += value; }
            remove { btBrowse.Click -= value; }
        }
    }
}
