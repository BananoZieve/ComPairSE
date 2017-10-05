using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPairSE
{
    public partial class MainForm : Form
    {
        IDataManager DataManager;

        public MainForm()
        {
            InitializeComponent();
            rbFile.Tag = pnFile;
            rbInput.Tag = tbInput;
            rbInput.Checked = true;
            rbFile.Checked = true;
#if DEBUG
            // project directory
            openFileDialog1.InitialDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
#else
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
#endif
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt";
#if OCR
            openFileDialog1.Filter += "|Image Files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
#endif
            this.Width -= this.ClientRectangle.Width - 2 * tbInput.Left - tbInput.Width;
            this.MinimumSize = this.Size;
            this.MaximumSize = new Size(this.Width, this.Height*2);

            DataManager = new DataManager();
        }

        private void btRnd_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<Item> list = new List<Item>();
            for (int i = 1; i <= rnd.Next(12,25); i++)
                list.Add(new Item(i.ToString(), rnd.Next(20)*100 + rnd.Next(2)*50 + 49, Shop.Maxima));
            Receipt receipt = Receipt.Create(Shop.Maxima, list);
            ReceiptForm receiptForm = new ReceiptForm(receipt);
            receiptForm.Show();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            Receipt receipt;
            if (rbInput.Checked)
            {
                receipt = Receipt.Create(tbInput.Text);
            }
            else
            {
                string data = string.Empty;
                switch (openFileDialog1.FilterIndex)
                {
                    case 1:
                        data = File.ReadAllText(tbFile.Text);
                        break;
                    default:
                        break;
                }
                receipt = Receipt.Create(data);
            }

            ReceiptForm receiptForm = new ReceiptForm(receipt);
            foreach (Item item in receipt.Items)
            {
                DataManager.AddItem(item);
            }
            receiptForm.Show();
        }

        private void button_SearchItemsByTag_Click(object sender, EventArgs e)
        {
            Receipt receipt = Receipt.Create(tbInput.Text);
            SearchByTagForm searchByTagForm = new SearchByTagForm();
            searchByTagForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DataManager.LoadData();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataManager.SaveData();
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                tbFile.Text = openFileDialog1.FileName;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                Control ctrl = rb.Tag as Control;
                if (ctrl != null)
                {
                    ctrl.Enabled = rb.Checked;
                }
            }
        }
    }
}
