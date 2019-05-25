using Rg.Plugins.Popup.Services;
using SerapisDoctor.View;
using SerapisDoctor.View.Pop_ups;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel
{
    public class PatientDetailsViewModel
    {

        private DoctorsNote notePop;

        private AnalyticsPopUp analyticsPopUp;

        public PatientDetailsViewModel()
        {
            notePop = new DoctorsNote();

            //Analytics pop up instance
            analyticsPopUp = new AnalyticsPopUp();

            PatientAnaylticsPortal = new Command(() => PatientAnaylicsPopUpPage());

            PrescriptionCommand = new Command(NavigateToPrescriptionForms);

            AddMedicalFiles = new Command(NavigateToAddMedFiles);

            DoctorsNoteCommand = new Command(NavigateToDoctorsNote);
        }

        public Command PrescriptionCommand { get; set; }
        public Command AddMedicalFiles { get; set; }
        public Command DoctorsNoteCommand { get; set; }

        public Command PatientAnaylticsPortal { get; set; }

        private async void NavigateToPrescriptionForms()
        {
            await App.Current.MainPage.Navigation.PushAsync(new DoctorPrescription());
        }

        private async void NavigateToAddMedFiles()
        {
            
        }

        private void PatientAnaylicsPopUpPage()
        {
            //Get from back end .net machine learning api
            PopupNavigation.Instance.PushAsync(analyticsPopUp);
        }

        private void NavigateToDoctorsNote()
        {
             PopupNavigation.Instance.PushAsync(notePop);
        }
    }
}
