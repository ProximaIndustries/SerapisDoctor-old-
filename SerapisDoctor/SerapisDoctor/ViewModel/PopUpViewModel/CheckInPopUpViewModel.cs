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
        #region Local Event handler
        public delegate void ButtonPressed(object sender, EventArgs args);

        public event ButtonPressed ButtonEvent;

        public void RaiseButtonPressed()
        {
            if (ButtonEvent != null)
                ButtonEvent(this, new EventArgs());
        }
        #endregion

        PatientMeta patientObj = new PatientMeta();

        public CheckInPopUpViewModel()
        {
            CheckInPatient = new Command(AddPatientToList);

            //temp code
            ClosePopup = new Command(CloseThePopUp);

            MessagingCenter.Subscribe<CheckInViewModel, PatientMeta>(this, MessagingKeys.PopUpObject, (obj, sender) =>
            {
                //subcribe to messging center
                patientObj = sender;

                //Set the values for the popup
                UserName = sender.FullName;
                ProfilePicture = sender.ProfilePicture;

                if (sender.IsDependent.Equals(true))
                {
                    Visibility = true;
                }
                else
                {
                    Visibility = false;
                }

            });
        }

        public Command CheckInPatient { get; set; }

        public Command ClosePopup { get; set; }


        //Adds patients meta-data into sqlite storage
        private void AddPatientToList()
        {
            RaiseButtonPressed();

            IsBusy = true;

            //Must be set to false, set to true for testing
            IsButtonEnabled = true;

            try
            {
                //Connect to the local database and insert item
                PatientsWaintingLineDb.InsertPatient(patientObj);

                //Remove from PatientAwaitingCheckIn
                PatientAwatingCheckIn.RemoveFromList(patientObj);

                Task.Delay(250);

                //Auto close the pop up afterwards
                PopupNavigation.Instance.PopAllAsync(true);

            }
            catch(Exception ex)
            {
                //also send error logging to backend 
                throw ex;
            }
            finally
            {
                IsBusy = false;

                IsButtonEnabled = true;
            }
        }
        
        private void CloseThePopUp()
        {
            IsButtonEnabled = false;

            try
            {
                PopupNavigation.Instance.PopAllAsync(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IsButtonEnabled = true;
            }
        }

        private bool visibility=false;

        public bool Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                OnPropertyChanged("Visibility");
                visibility = value;
            }
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
