using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using System.IO;

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

            //Sqlite storage android code
            string fileName = "patients_db.db3";

            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            //Combines the name and the path
            string completePath = Path.Combine(folderPath, fileName);

            LoadApplication(new App(completePath));
        }
    }
}

