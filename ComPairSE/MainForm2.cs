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
    public partial class MainForm2 : Form
    {
        public MainForm2(IDataManager dataManager)
        {
            InitializeComponent();
            this.Width -= this.ClientRectangle.Width - homePage1.Width;
            this.Height -= this.ClientRectangle.Height - homePage1.Height;
            DataManager = dataManager;
            searchPage1.DataManager = dataManager;
            scanPage1.DataManager = dataManager;
        }

        private IDataManager DataManager;

        private void MainForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataManager.SaveData();
        }

        private void homePage1_ScanClick(object sender, EventArgs e)
        {
            if (scanPage1 != null) { scanPage1.Visible = true; homePage1.Visible = false; }
        }

        private void homePage1_SearchClick(object sender, EventArgs e)
        {
            if (searchPage1 != null) { searchPage1.Visible = true; homePage1.Visible = false; }
        }

        private void homePage1_BrowseClick(object sender, EventArgs e)
        {
            if (receiptHistoryPage1 != null) { receiptHistoryPage1.Visible = true; homePage1.Visible = false; }
        }
    }
}
