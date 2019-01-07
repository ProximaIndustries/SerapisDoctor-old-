using SerapisDoctor.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            WaitingListCommand = new Command(async()=>await GoToPatientDiagnosisListAsync());
        }

        public Command WaitingListCommand { get; set; }

        private async Task GoToPatientDiagnosisListAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new PatientInWaiting());
        }

    }
}
