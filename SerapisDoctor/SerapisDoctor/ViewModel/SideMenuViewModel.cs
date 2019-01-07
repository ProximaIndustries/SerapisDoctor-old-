using SerapisDoctor.Utils;
using SerapisDoctor.View;
using SerapisDoctor.View.SideMenuPages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel
{
    public class SideMenuViewModel:BaseViewModel,IInitailGenerator
    {
        public SideMenuViewModel()
        {
            HomeCommand = new Command(async() => await GoBackHomeAsync());
            SettingsCommand = new Command(async () => await GoToSettingsPageAsync());
            ActivityCommand = new Command(async () => await GoToPracticeStatsAsync());
            ManagePracticeCommand = new Command(async () => await GoToManageDocsAsync());
            HelpCommand = new Command(async () => await GoToHelpAsync());
            LogOutCommand = new Command(async () => await LogDoctorOutAsync());
        }


        #region SideMenu Command Properties
        public Command HomeCommand { get; set; }
        public Command SettingsCommand { get; set; }
        public Command ActivityCommand { get; set; }
        public Command ManagePracticeCommand { get; set; }
        public Command HelpCommand { get; set; }
        public Command LogOutCommand { get; set; }
        #endregion

        #region Properties
        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string profilePicture;
        public string ProfilePicture
        {
            get
            {
                return profilePicture;
            }
            set
            {
                profilePicture = value;
                OnPropertyChanged("ProfilePicture");
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }


        #endregion

        #region Methods
        public char FirstNameInitial(string firstName)
        {
            throw new NotImplementedException();
        }

        public char MiddleNameInital(string middleName)
        {
            throw new NotImplementedException();
        }


        private async Task GoToSettingsPageAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }


        private async Task GoToPracticeStatsAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new StatsPage());
        }

        private async Task GoToManageDocsAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ManageDocsPage());
        }

        private async Task GoToHelpAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Help());
        }

        private async Task GoBackHomeAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        private async Task LogDoctorOutAsync()
        {
            //Code to log the doc out the app
        }
        #endregion
    }
}
