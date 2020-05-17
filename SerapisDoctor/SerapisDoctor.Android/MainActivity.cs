using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using System.IO;
using Lottie.Forms.Droid;

namespace SerapisDoctor.Droid
{
    [Activity(Label = "SerapisDoctor", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Rg.Plugins.Popup.Popup.Init(this,bundle);
            CarouselViewRenderer.Init();
            base.OnCreate(bundle);


            global::Xamarin.Forms.Forms.Init(this, bundle);

            //Set the status bar color.
            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#607d8b"));

            //GPs code
            Xamarin.Essentials.Platform.Init(this, bundle);

            //Sqlite storage android code
            string fileName = "patients_db.db3";

            string completePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), fileName);
            //    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));


            LoadApplication(new App(completePath));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

