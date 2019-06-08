using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SerapisDoctor.Global_Lists;
using SerapisDoctor.Model.Patient; //This Is Temporary for testing only
using SerapisDoctor.Utils;
using SerapisDoctor.View.Pop_ups;
using SerapisDoctor.ViewModel.TabbedPageViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SerapisDoctor.Services;

namespace SerapisDoctor.ViewModel.PopUpViewModel
{
    public class CheckInPopUpViewModel : BaseViewModel
    {
        Patient patientObj = new Patient();

        public CheckInPopUpViewModel()
        {
            CheckInPatient = new Command(AddPatientToList);

            //temp code
            ClosePopup = new Command(CloseThePopUp);

            MessagingCenter.Subscribe<CheckInViewModel, Patient>(this, MessagingKeys.PopUpObject, (obj, sender) =>
            {
                UserName = sender.FullName;
                ProfilePicture = sender.PatientProfilePicture;
                patientObj.PatientProfilePicture = sender.PatientProfilePicture;
                patientObj.FullName = sender.FullName;
                patientObj.PatientLastName = sender.PatientLastName;
                patientObj.PatientFirstName = sender.PatientFirstName;
                patientObj.PatientBloodType = sender.PatientBloodType;
                patientObj.PatientMedicalAid = sender.PatientMedicalAid;
                patientObj.Appointment = sender.Appointment;
                patientObj.HasBloodPressure = sender.HasBloodPressure;
                patientObj.IsDepenedent = sender.IsDepenedent;
                patientObj.ListOfChronicDisease = sender.ListOfChronicDisease;
                patientObj.MedicalAidPatient = sender.MedicalAidPatient;
                patientObj.ListOfMedication = sender.ListOfMedication;
                patientObj.ListOfAllergies = sender.ListOfAllergies;
                patientObj.PatientAge = sender.PatientAge;
                
            });
        }

        public Command CheckInPatient { get; set; }

        public Command ClosePopup { get; set; }


        //Adds patients meta-data into sqlite storage
        private void AddPatientToList()
        {

            //1.Add to the Local storage database
            PateintMeta metaData = new PateintMeta()
            {
                FullName = patientObj.FullName,
                ProfilePicture=patientObj.PatientProfilePicture,
                Id=patientObj.Id.ToString()
            };

            //2.Connect to the local database and insert item
            PatientsWaintingLineDb.InsertPatient(metaData);

            //Remove from PatientAwaitingCheckIn
            PatientAwatingCheckIn.RemoveFromList(patientObj);

            PopupNavigation.Instance.PopAllAsync(true);
        }
        

        private void CloseThePopUp()
        {
            PopupNavigation.Instance.PopAllAsync(true);
        }

        private string profilePicture;
        public string ProfilePicture
        {
            get
            {
                return  profilePicture;
            }
            set
            {

                profilePicture = value;
                OnPropertyChanged("ProfilePicture");
                profilePicture = value; ;
            }
        }


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
                userName = value;
            }
        }


    }
}
