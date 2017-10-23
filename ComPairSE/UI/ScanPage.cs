using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ComPairSE.UI
{
    public partial class ScanPage : Page
    {
        public ScanPage()
        {
            InitializeComponent();
        }

        public IDataManager DataManager { get; set; }

        [Browsable(true)]
        public OpenFileDialog OpenFileDialog
        {
            get { return openFileDialog; }
        }

        protected override void OnNextButtonClick(EventArgs e)
        {
            // create receipt and send it to receiptViewPage
            if (tbFile.Text != string.Empty)
            {
                ReceiptPage receiptPage = NextPage as ReceiptPage;
                Receipt receipt = Receipt.Create(File.ReadAllText(tbFile.Text));
                receiptPage.Receipt = receipt;
                foreach (Item item in receipt.Items)
                    DataManager.AddItem(item);
                base.OnNextButtonClick(e);
            }
#if DEBUG
            else base.OnNextButtonClick(e);
#endif
        }

        private void ScanPage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void ScanPage_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1)
            {
                switch (Path.GetExtension(files[0]))
                {
                    case ".txt":
                    case ".png":
                    case ".jpg":
                    case ".bmp":
                        tbFile.Text = files[0];
                        label1.Text = Path.GetFileName(files[0]);
                        break;
                    default:
                        break;
                }
            }
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbFile.Text = openFileDialog.FileName;
                label1.Text = openFileDialog.SafeFileName;
            }
        }

        private void tbFile_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
