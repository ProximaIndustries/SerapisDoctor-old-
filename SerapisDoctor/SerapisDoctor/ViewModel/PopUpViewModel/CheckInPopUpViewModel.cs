using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SerapisDoctor.Global_Lists;
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
using SerapisDoctor.Model.PatientModel;

namespace SerapisDoctor.ViewModel.PopUpViewModel
{
    public class CheckInPopUpViewModel : BaseViewModel
    {
        PatientMeta patientObj = new PatientMeta();

        public CheckInPopUpViewModel()
        {
            CheckInPatient = new Command(AddPatientToList);

            //temp code
            ClosePopup = new Command(CloseThePopUp);

            MessagingCenter.Subscribe<CheckInViewModel, PatientMeta>(this, MessagingKeys.PopUpObject, (obj, sender) =>
            {
                UserName = sender.FullName;
                ProfilePicture = sender.ProfilePicture;
            });
        }

        public Command CheckInPatient { get; set; }

        public Command ClosePopup { get; set; }


        //Adds patients meta-data into sqlite storage
        private void AddPatientToList()
        {

            //1.Add to the Local storage database
            PatientMeta metaData = new PatientMeta()
            {
                FullName = patientObj.FullName,
                ProfilePicture = patientObj.ProfilePicture,
                Id = patientObj.Id.ToString(),
                IsMedicalAidPatient = false
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
