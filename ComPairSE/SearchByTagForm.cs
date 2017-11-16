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
    public partial class SearchByTagForm : Form
    {
        public SearchByTagForm()
        {
            InitializeComponent();
        }

        private void label_Tag_Click(object sender, EventArgs e)
        {

        }

        private void SearchByTagForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox_ForSearching_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_SearchByTag_Click(object sender, EventArgs e)
        {
            FoundItemsByTagForm foundItemsByTagForm = new FoundItemsByTagForm();
            foundItemsByTagForm.Show();
        }
    }
}
