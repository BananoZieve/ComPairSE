using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPairSE
{
    class UserConfigurations
    {

        public void ReceiptsDataSharing()
        {
            if (!Properties.Settings.Default.ReceiptsDataSharing)
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to help the creators in collecting the receipts data? \n \n (Disclaimer: all the data gathered will be anonymous)", "Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Properties.Settings.Default.ReceiptsDataSharing = true;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Thank you for your contribution!");
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("You can always change you choice in the Settings!");
                }
            }
        }
    }
}
