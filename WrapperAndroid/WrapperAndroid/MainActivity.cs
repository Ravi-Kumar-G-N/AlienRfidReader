using System;
using System.Runtime.CompilerServices;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Alien.Barcode;
using Com.Alien.Common;
using Com.Alien.Rfid;
using Java.Interop;

namespace WrapperAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //private RFIDReader _reader = null;

        private BarcodeReader barcodeReader = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            //_reader = RFID.Open();
            //RFIDResult resulrt = _reader.Read();
            ////this.OnTagRead += OnTagggReade;
            //_reader.Inventory(new CallBack());

            //if (resulrt.IsSuccess)
            //{
            //    Tag tag = (Tag)resulrt.Data;
            //    string epc = tag.EPC;
            //    double rssi = tag.RSSI;
            //    //var rssiPer = tag.
            //}
            //var intance = new MainBase();
            //var test = intance.MyMethod(12);
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            //DeviceInfo dev = new DeviceInfo(this);
            //var deviceId = dev.DeviceID;

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            barcodeReader =  new BarcodeReader(this.ApplicationContext);
            if (!barcodeReader.IsRunning)
                barcodeReader.Start(new BarcodeCallback());

           // _reader.Inventory(new CallBack());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool DispatchKeyEvent(KeyEvent e)
        {
           //// return true;
           // Console.WriteLine(e.Action);
           // if (e.Action == KeyEventActions.Down)
           // {
           //     if (!_reader.IsRunning)
           //     {
           //       //  Console.WriteLine("Start Reader");
           //     _reader.Inventory(new CallBack());
           //         //_reader.Stop();

           //     }
           //     //Console.WriteLine("Starting Reader.");
           // }
           // else if (e.Action == KeyEventActions.Up && _reader.IsRunning)
           // {
           //    // Console.WriteLine("Stoppping Reader");
           //     _reader.Stop();

           // }

            return true;
        }

    }

    public class CallBack : Java.Lang.Object, IRFIDCallback
    {
        public void CallBac()
        {

        }

        public void OnTagRead(Tag p0)
        {
           // Console.WriteLine(p0.EPC);
        }
    }

    public class BarcodeCallback : Java.Lang.Object, IBarcodeCallback
    {
        public void OnBarcodeRead(string p0)
        {
            Console.WriteLine(p0);
        }
    }
}

