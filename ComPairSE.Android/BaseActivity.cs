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
    [Activity(Label = "BaseActivity")]
    public class BaseActivity : Activity
    {
        protected int LayoutId = Resource.Layout.BaseLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(LayoutId);
            InitControls();
        }

        protected virtual void InitControls()
        {
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

        public override void Finish()
        {
            base.Finish();
        }
    }
}