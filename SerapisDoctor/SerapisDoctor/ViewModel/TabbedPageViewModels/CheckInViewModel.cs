using Rg.Plugins.Popup.Services;
using SerapisDoctor.Global_Lists;
using SerapisDoctor.Model.AppointmentModel;
using SerapisDoctor.Model.Patient;
using SerapisDoctor.Services;
using SerapisDoctor.Utils;
using SerapisDoctor.View.Pop_ups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel.TabbedPageViewModels
{
     public class CheckInViewModel:BaseViewModel
    {
        public ObservableCollection<Patient> ListOfBookedPatients { get; set; }

        private CheckInPopUp popUp;

        

        private Patient Patient;
        private Patient Patient2;

        public Command PatientAnaylticsPortal { get; set; }

        public CheckInViewModel()
        {
            
             GenerateDummyList();
            //GenerateDummyList2Async(); !!!use when api with azure is up and running
            popUp = new CheckInPopUp();

            
        }

        private void GenerateDummyList()
        {
            Appointment appointment = new Appointment();

            ListOfBookedPatients = new ObservableCollection<Patient>();

            Patient = new Patient()
            {
                 PatientProfilePicture="userplaceholder.png",
                 FullName="Khanyisani Buthelezi",
                 Gender=Model.Enum.Genders.male,
                 HasBloodPressure=false,
                 IsDepenedent=false,
                 ListOfAllergies=null,
                 MedicalAidPatient=true,
                 PatientAge=22,
                 Appointment=new Appointment { DateBooked=DateTime.Today.ToShortDateString(), TimeBooked=DateTime.Today.ToShortTimeString() }
            };

            Patient2 = new Patient();
        
            PatientAwatingCheckIn.AddPatient(Patient2);

            PatientAwatingCheckIn.AddPatient(Patient);

            ListOfBookedPatients = PatientAwatingCheckIn.PatientsBooked;
        }


        private async Task GenerateDummyList2Async()
        {
            BookingApi bookedPatient_today = new BookingApi();

            await bookedPatient_today.GetBookedPatientsAsync();
        }

        public ICommand SelectPatient => new Command<Patient>(patient =>
        {

            Patient obj = new Patient()
            {
                FullName = patient.FullName,
                MedicalAidPatient = patient.MedicalAidPatient,
                PatientProfilePicture = patient.PatientProfilePicture,
                Appointment = patient.Appointment,
                Gender = patient.Gender,
                HasBloodPressure = patient.HasBloodPressure,
                IsDepenedent = patient.IsDepenedent,
                PatientMedicalAid = patient.PatientMedicalAid,
                PatientAge = patient.PatientAge,
                PatientBloodType = patient.PatientBloodType,
                PatientFirstName = patient.PatientFirstName,
                PatientLastName = patient.PatientLastName,
                ListOfAllergies = patient.ListOfAllergies,
                ListOfChronicDisease = patient.ListOfChronicDisease,
                ListOfMedication = patient.ListOfMedication,
            };

            //Send the object to the pop up.
            MessagingCenter.Send(this, MessagingKeys.PopUpObject, obj);
            
            //Brings up the pop up dialog box
            PopupNavigation.Instance.PushAsync(popUp);
        });

    }
}
