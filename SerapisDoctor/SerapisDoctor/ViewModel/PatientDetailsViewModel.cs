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

        public PatientDetailsViewModel()
        {
            notePop = new DoctorsNote();
            PrescriptionCommand = new Command(NavigateToPrescriptionForms);
            AddMedicalFiles = new Command(NavigateToAddMedFiles);
            DoctorsNoteCommand = new Command(NavigateToDoctorsNote);
        }

        public Command PrescriptionCommand { get; set; }
        public Command AddMedicalFiles { get; set; }
        public Command DoctorsNoteCommand { get; set; }


        private async void NavigateToPrescriptionForms()
        {
            await App.Current.MainPage.Navigation.PushAsync(new DoctorPrescription());
        }

        private async void NavigateToAddMedFiles()
        {
            
        }

        private void NavigateToDoctorsNote()
        {
             PopupNavigation.Instance.PushAsync(notePop);
        }
    }
}
