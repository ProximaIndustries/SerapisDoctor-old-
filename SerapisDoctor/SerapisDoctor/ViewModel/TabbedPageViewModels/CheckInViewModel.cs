using Rg.Plugins.Popup.Services;
using SerapisDoctor.Global_Lists;
using SerapisDoctor.Model.AppointmentModel;
using SerapisDoctor.Model.PatientModel;
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
        public int LineNumber = 0;

        public ObservableCollection<PatientMeta> ListOfBookedPatients { get; set; }

        private CheckInPopUp popUp;

        public Command LoadItemsCommand { get; set; }

        public CheckInViewModel()
        {

            GenerateDummyList();
            //GenerateDummyList2Async(); !!!use when api with azure is up and running
            popUp = new CheckInPopUp();

            LoadItemsCommand = new Command(() => 
            {
                RefreashPatientsBooked();
                
            });
        }


        //Mock 
        private void GenerateDummyList()
        {
            ListOfBookedPatients = new ObservableCollection<PatientMeta>();

            foreach (var patient in PatientAwatingCheckIn.GetPatients())
            {
                ListOfBookedPatients.Add(patient);
            }
        }


        private void RefreashPatientsBooked()
        {
            IsRefreshing = true;

            IsBusy = true;

            try
            {
                //Try look for more booked patients for the day in the server (Services)

                //the follwing is dummy data to test to removed when back end configured
                var patientAdded=DataStore.GetRefereshedBookedPatients();

                PatientAwatingCheckIn.AddPatient(patientAdded);
            }
            catch (Exception)
            {
                //Send the error log to server.
                throw;
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        #region Use when the api is live
        private async Task GenerateDummyList2Async()
        {
            BookingApi bookedPatient_today = new BookingApi();

            await bookedPatient_today.GetBookedPatientsAsync();
        }
        #endregion


        public ICommand SelectPatient => new Command<PatientMeta>(patient =>
        {
            IsBusy = true;

            LineNumber++;

            try
            {
                PatientMeta obj = new PatientMeta()
                {
                    FullName = patient.FullName,
                    ProfilePicture = patient.ProfilePicture,
                    Id = " ",
                    LineNumber = this.LineNumber
                };

                //Send the object to the pop up.
                MessagingCenter.Send(this, MessagingKeys.PopUpObject, obj);

                PatientAwatingCheckIn.RemoveFromList(obj);

                //Brings up the pop up dialog box
                PopupNavigation.Instance.PushAsync(popUp);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        });

    }
}
