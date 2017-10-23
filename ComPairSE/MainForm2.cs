using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPairSE
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

        private void btScan_Click(object sender, EventArgs e)
        {
            if (scanPage1 != null) { scanPage1.Visible = true; homePage1.Visible = false; }
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            if (searchPage1 != null) { searchPage1.Visible = true; homePage1.Visible = false; }
        }

        private void MainForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataManager.SaveData();
        }

        //private void btBrowse_Click(object sender, EventArgs e)
        //{
        //    if (BrowsePage != null) { BrowsePage.Visible = true; this.Visible = false; }
        //}
    }
}
