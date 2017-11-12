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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            if (Properties.Settings.Default.ReceiptsDataSharing == true) receiptsData.Checked = true;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnCheck(object sender, EventArgs e)
        {
            if (receiptsData.Checked) Properties.Settings.Default.ReceiptsDataSharing = true;
            else Properties.Settings.Default.ReceiptsDataSharing = false;
        }
    }
}
