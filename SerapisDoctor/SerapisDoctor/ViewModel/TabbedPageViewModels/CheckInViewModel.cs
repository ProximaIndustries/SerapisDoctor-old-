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

        private void GenerateDummyList()
        {
            ListOfBookedPatients = new ObservableCollection<Patient>();

            ListOfBookedPatients = PatientAwatingCheckIn.GetPatients();
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

        private async Task GenerateDummyList2Async()
        {
            BookingApi bookedPatient_today = new BookingApi();

            await bookedPatient_today.GetBookedPatientsAsync();
        }

        public ICommand SelectPatient => new Command<Patient>(patient =>
        {
            IsBusy = true;

            try
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
