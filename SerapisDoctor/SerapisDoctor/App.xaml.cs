using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SerapisDoctor.View;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using SerapisDoctor.Model.Patient;
using System.Collections.ObjectModel;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SerapisDoctor
{
	public partial class App : Application
	{
        #region Microsoft Graph credentials
        public static string ClientId = "706e42e5-cd0d-457d-9f85-0c4862557b94";
        public static string[] Scopes = {"Calendars.ReadWrite"};
        public static PublicClientApplication PCA = null;
        public static string RedirectAddress = $"msal//{ClientId}://auth";
        public static UIParent UiPartent;
        #endregion

        public App ()
		{
			InitializeComponent();

            PCA = new PublicClientApplication(ClientId)
            {
                RedirectUri = RedirectAddress
            };

			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
