using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace ComPairSE.Android
{
    [Activity(Label = "ComPairSE Home", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button buttonScan = FindViewById<Button>(Resource.Id.buttonScan);
            Button buttonCreate = FindViewById<Button>(Resource.Id.buttonCreate);
            Button buttonHistory = FindViewById<Button>(Resource.Id.buttonHistory);
            Button buttonTest = FindViewById<Button>(Resource.Id.buttonTest);

            buttonScan.Click += (sender, e) =>
            {
                StartActivity(typeof(ReceiptScanActivity));
            };
            buttonCreate.Click += (sender, e) =>
            {
                StartActivity(typeof(ReceiptCreateActivity));
            };
            buttonHistory.Click += (sender, e) =>
            {
                StartActivity(typeof(ReceiptHistoryActivity));
            };
            buttonTest.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(BaseActivity));
                StartActivity(intent);
            };
        }
    }
}

