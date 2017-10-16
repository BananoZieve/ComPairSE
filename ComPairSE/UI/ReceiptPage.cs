using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPairSE.UI
{
    public partial class ReceiptPage : Page
    {
        public ReceiptPage()
        {
            InitializeComponent();
        }

        public ReceiptViewCollection Receipts
        {
            get;
        }

        public class ReceiptViewCollection : List<ReceiptView>
        {

        }

    }
}
