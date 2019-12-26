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
    public class SideMenuViewModel : BaseViewModel
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
        private string initialsString;

        public string InitialsString
        {
            get
            {
                return initialsString = char.ToString(InitialGenerator.GenerateFirstNameInitial(myName));
            }
            set
            {
                initialsString = value;
            }
        }

        string myName = "khanyisani";

        private string displayName;
        public string DisplayeName
        {
            get
            {
                displayName = " " + InitialsString + "." +" "+ Surname;
                return displayName;
            }
            set
            {
                displayName = value;
                OnPropertyChanged("DisplayName");
                displayName = value;
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

        private string surname="Buthelezi";
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
                surname = value;
            }
        }

        


        #endregion

        #region Methods

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
