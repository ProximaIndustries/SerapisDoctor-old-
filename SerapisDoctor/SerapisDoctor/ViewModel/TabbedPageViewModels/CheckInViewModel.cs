using Rg.Plugins.Popup.Services;
using SerapisDoctor.Global_Lists;
using SerapisDoctor.Model.PatientModel;
using SerapisDoctor.Services;
using SerapisDoctor.Utils;
using SerapisDoctor.View.Pop_ups;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using SerapisDoctor.ViewModel.PopUpViewModel;
using Microsoft.Graph;
using MongoDB.Bson;

namespace SerapisDoctor.ViewModel.TabbedPageViewModels
{
    public class CheckInViewModel:BaseViewModel
    {

        private ObservableCollection<PatientMeta> listOfBookedPatients;

        //An instance of a class for the network error page
        private ErrorPopUp errorPop;


        public ObservableCollection<PatientMeta> ListOfBookedPatients
        {
            get
            {
                return listOfBookedPatients;
            }
            set
            {
                listOfBookedPatients = value;
                PatientAwatingCheckIn.UpdateList();
                listOfBookedPatients = value;
            }
        }

        //An instance to make the check in pop up page
        private CheckInPopUp popUp;

        public Command LoadItemsCommand { get; set; }

        public CheckInViewModel()
        {

            GenerateDummyList();
            //GenerateDummyList2Async(); !!!use when api with azure is up and running
            popUp = new CheckInPopUp();

            errorPop = new ErrorPopUp();

            //Listens to weather or not the internet connectivity has changed
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            LoadItemsCommand = new Command(() => 
            {
                RefreashPatientsBooked();
            });

        }

        //Desconstructor to unsubcribe to any events to save memory
         ~CheckInViewModel()
        {

        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess != NetworkAccess.Internet)
            {
                //Messaging center sends some info to change the errorPopUp notification
                MessagingCenter.Send<CheckInViewModel, string>(this, MessagingKeys.ErrorPopUpBanner, "Connection error");

                PopupNavigation.Instance.PushAsync(errorPop);
            }
            else
            {
                //Messaging center sends some info to change the errorPopUp notification
                MessagingCenter.Send<CheckInViewModel, string>(this, MessagingKeys.ErrorPopUpBanner, "Connection estblished");

                
                //Return the page with diffrent properties
                PopupNavigation.Instance.PushAsync(errorPop);

                //wait a second then automatically close the banner
                Task.Delay(4000);

                //code to automatically close the banner
                PopupNavigation.Instance.PopAllAsync(true);
            }
        }


        //Mock 
        private void GenerateDummyList()
        {
            ListOfBookedPatients = new ObservableCollection<PatientMeta>();

            ListOfBookedPatients = PatientAwatingCheckIn.GetPatients();
        }


        private void RefreashPatientsBooked()
        {
            IsRefreshing = true;

            IsBusy = true;

            try
            {
                //Try look for more booked patients for the day in the server (Services)

                if (Connectivity.NetworkAccess != NetworkAccess.None)
                {
                    //the follwing is dummy data to test to removed when back end configured
                    var patientAdded = DataStore.GetRefereshedBookedPatients();

                    PatientAwatingCheckIn.AddPatient(patientAdded);
                }
                else
                {
                    PopupNavigation.Instance.PushAsync(errorPop);
                }
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

            try
            {
                PatientMeta obj = new PatientMeta()
                {
                    FullName = patient.FullName,
                    ProfilePicture = patient.ProfilePicture,
                    Id = "",
                    Appointment = new Model.AppointmentModel.Appointment
                    {
                        
                        DateBooked = DateTime.Today,
                        HasSeenGP = true,
                        TimeBooked = new DateTime(2000),
                        BookingId = ObjectId.Parse(""),
                        Duration = TimeSpan.FromSeconds(1),
                    }
                };

                //Send the object to the pop up.
                MessagingCenter.Send(this, MessagingKeys.PopUpObject, obj);

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
