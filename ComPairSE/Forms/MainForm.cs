#define OCR
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace ComPairSEBack
{
    public partial class MainForm : Form
    {
        UserConfigurations userconfig;
        IOCR Ocr;
        ComPairSE.FirstService.DataServiceClient firstServiceClient;

        public MainForm()
        { 

            InitializeComponent();
            rbFile.Tag = btBrowse;
            rbInput.Tag = tbInput;
            rbFile.Checked = rbInput.Checked = true;

            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
#if OCR
            openFileDialog.Filter += "|Image Files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
#endif
#if DEBUG   // project directory
            openFileDialog.InitialDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
#else       // my docs
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
#endif
            
           // this.Width -= this.ClientRectangle.Width - 2 * tbInput.Left - tbInput.Width;
            this.MinimumSize = this.Size; 
            this.MaximumSize = new Size(this.Width, 1080);

            userconfig = new UserConfigurations();
            Ocr = new TesseractOCR();
            firstServiceClient = new ComPairSE.FirstService.DataServiceClient();
        }

        private void btRnd_Click(object sender, EventArgs e)
        {
           /* Random rnd = new Random();
            List<Item> list = new List<Item>();
            for (int i = 1; i <= rnd.Next(12,25); i++)
                list.Add(new Item(i.ToString(), rnd.Next(20)*100 + rnd.Next(2)*50 + 49, ShopEnum.Maxima));
            Receipt receipt = Receipt.Create(ShopEnum.Maxima, list);
            ReceiptForm receiptForm = new ReceiptForm(receipt);
            receiptForm.Show();
            */
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
                userconfig.ReceiptsDataSharing();

                string data = string.Empty;
            if (rbInput.Checked)
            {
                if (tbInput.Text == string.Empty) { toolTip.Show("Empty field", tbInput, 3000); return; }
                data = tbInput.Text;
            }
            else
            {
                if (tbFile.Text == string.Empty) { toolTip.Show("Empty field", tbFile, 3000); return; }
                switch (openFileDialog.FilterIndex)
                {
                    case 1:
                        data = File.ReadAllText(tbFile.Text); break;
                    case 2:
                        data = Ocr.GetText(tbFile.Text); break;
                    default:
                        break;
                }
            }
            var response = firstServiceClient.CreateReceipt(data);
            ReceiptForm receiptForm = new ReceiptForm(JObject.Parse(response));
            receiptForm.Show();
            /* 
                      //DataManager.ClarificationSystem(item);
              */
        }

        private void button_SearchItemsByTag_Click(object sender, EventArgs e)
        {
            SearchByTagForm searchByTagForm = new SearchByTagForm();
            searchByTagForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
          firstServiceClient.LoadDataFromFile();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            firstServiceClient.SaveDataToFile();
        }

        private void ClickOcr(object sender, EventArgs e)
        {
            if (openFileDialog.FilterIndex == 2 && tbFile.Text != string.Empty)
                MessageBox.Show(Ocr.GetText(tbFile.Text));
        }
        
        private void btBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbFile.Text = openFileDialog.FileName;
                toolTip.SetToolTip(tbFile, tbFile.Text);
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                Control ctrl = rb.Tag as Control;
                if (ctrl != null)
                    ctrl.Enabled = rb.Checked;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            HistoryForm form = new HistoryForm(this);
            form.Show();
        }

        private void userSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().Show();
        }
    }
}
