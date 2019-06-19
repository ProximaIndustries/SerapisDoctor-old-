using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SerapisDoctor.View;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SerapisDoctor.Services;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SerapisDoctor
{

    //This file needs to made neater and cleaner.

	public partial class App : Application
	{
        #region Microsoft Graph credentials
        public static string ClientId = "706e42e5-cd0d-457d-9f85-0c4862557b94";
        public static string[] Scopes = {"Calendars.ReadWrite"};
        public static PublicClientApplication PCA = null;
        public static string RedirectAddress = $"msal//{ClientId}://auth";
        public static UIParent UiPartent;
        #endregion

        #region Properties (Local database)
        public static string Database=string.Empty;
        #endregion

        public Location trackLocation { get; set; }

        public App ()
		{
            InitializeComponent();

            try
            {
             
                //Get the doctors events from microsoft outlook
                PCA = new PublicClientApplication(ClientId)
                {
                    RedirectUri = RedirectAddress
                };

                MainPage = new NavigationPage(new MainPage());
            }
            catch (Exception ex)
            {
                throw ex;
            }

		}

        //Second construtor for local storage options 
        public App(string filePath)
        {
            InitializeComponent();

            Database = filePath;

            MainPage = new NavigationPage(new MainPage());
        }

		protected override void OnStart ()
		{
            // Handle when your app starts

            /*
             * Clear the local database **More logic based on time etc. 
             * needed This will have to do for now
            */
             PatientsWaintingLineDb.ClearLocalDatabase();

            //Get doctors location
            DoctorLocationTracker doctorLocationTracker = new DoctorLocationTracker();

            Task.FromResult(doctorLocationTracker.GetCurrentLocationAsync());

        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes

            //Check the location first
		}
	}
}
