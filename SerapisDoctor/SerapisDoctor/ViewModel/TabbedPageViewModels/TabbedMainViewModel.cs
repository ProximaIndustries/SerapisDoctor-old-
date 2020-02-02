using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SerapisDoctor.Services.Data;
using SerapisDoctor.Services;

namespace SerapisDoctor.ViewModel.TabbedPageViewModels
{
    public class TabbedMainViewModel
    {
        public TabbedMainViewModel()
        {
            testCommand = new Command(RunTest);
        }

        public Command testCommand { get; set; }

        private async void RunTest()
        {
            BookingApi apiCall = new BookingApi();

            await apiCall.GetBookedPatientsAsync();

            await App.Current.MainPage.DisplayAlert("It worked", "Worked", "cancel");
        }
    }
}
