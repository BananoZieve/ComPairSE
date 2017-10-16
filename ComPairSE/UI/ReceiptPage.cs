using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

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
            private set;
        }

        public class ReceiptViewCollection : IList, ICollection, IEnumerable
        {
            public object this[int index]
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public bool IsReadOnly { get { throw new NotImplementedException(); } }

            public bool IsFixedSize { get { throw new NotImplementedException(); } }

            public int Count { get { throw new NotImplementedException(); } }

            public object SyncRoot { get { throw new NotImplementedException(); } }

            public bool IsSynchronized { get { throw new NotImplementedException(); } }

            public int Add(object value)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(object value)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public int IndexOf(object value)
            {
                throw new NotImplementedException();
            }

            public void Insert(int index, object value)
            {
                throw new NotImplementedException();
            }

            public void Remove(object value)
            {
                throw new NotImplementedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }
        }

    }
}
