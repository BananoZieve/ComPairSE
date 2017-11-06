using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ComPairSE.Android
{
    [Activity(Label = "ReceiptScanActivity")]
    public class ReceiptScanActivity : BaseActivity
    { 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            LayoutId = Resource.Layout.ReceiptScanLayout;
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}