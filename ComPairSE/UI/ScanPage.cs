﻿using System;
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
            NextButton.Enabled = false;
        }

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
                Receipt receipt = Receipt.Create(File.ReadAllText(tbFile.Text));
                (NextPage as ReceiptPage).Receipts.Add(new ReceiptView(receipt));
                base.OnNextButtonClick(e);
            }
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
                //toolTip.SetToolTip(tbFile, tbFile.Text);
            }
        }

        private void tbFile_TextChanged(object sender, EventArgs e)
        {
            NextButton.Enabled = tbFile.Text != string.Empty;
        }
    }
}