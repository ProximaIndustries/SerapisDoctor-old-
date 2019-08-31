using Rg.Plugins.Popup.Services;
using SerapisDoctor.Model.PatientModel;
using SerapisDoctor.Utils;
using SerapisDoctor.View;
using SerapisDoctor.View.Pop_ups;
using SerapisDoctor.View.Pop_ups.TilePopups;
using SerapisDoctor.ViewModel.PopUpViewModel.TilePopUpsViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel
{
    public class PatientDetailsViewModel:BaseViewModel
    {
        #region Local Event handler
        public delegate void ButtonPressed(object sender, EventArgs args);

        public event ButtonPressed ButtonEvent;

        public void RaiseButtonPressed()
        {
            if (ButtonEvent != null)
                ButtonEvent(this,new EventArgs());
        }
        #endregion

        private Patient patientInfo;

        private DoctorsNote notePop;

        private AnalyticsPopUp analyticsPopUp;

        private TilePopMedicalDetails tileMedicalDetailPopUp;

        private UpperTilePopUpMedicalDetails upperTileMedicalDetails;

        public PatientDetailsViewModel()
        {
            notePop = new DoctorsNote();

            //Analytics pop up instance
            analyticsPopUp = new AnalyticsPopUp();

            tileMedicalDetailPopUp = new TilePopMedicalDetails();

            upperTileMedicalDetails = new UpperTilePopUpMedicalDetails();

            PatientAnaylticsPortal = new Command(() => PatientAnaylicsPopUpPage());

            PrescriptionCommand = new Command(
                execute:()=> 
                {
                    NavigateToPrescriptionForms();
                }, canExecute:()=> 
                {
                    if (IsButtonEnabled.Equals(true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });

            AddMedicalFiles = new Command(NavigateToAddMedFiles);

            DoctorsNoteCommand = new Command(NavigateToDoctorsNote);

            ChronicDiseasePopUp = new Command(GenerateChronicDiseasePopUp);

            MedicalFilesNotePopUp = new Command(GenerateMedicalFilesNotePopUp);

            MedicationPopUp = new Command(GenerateMedicationPopUp);

            AllergiesPopUp = new Command(GenerateAllergiesPopUp);

            AgePopUp = new Command(GenerateAgePopUp);

            BloodTypePopUp = new Command(GenerateBloodTypePopUp);

            BloodPressurePopUp = new Command(GenerateBloodPressurePopUp);

            GenderPopUp = new Command(GenerateGenderPopUp);
        }

        ~PatientDetailsViewModel()
        {
            
        }

        #region Command properties
        public Command PrescriptionCommand { get; set; }
        public Command AddMedicalFiles { get; set; }
        public Command DoctorsNoteCommand { get; set; }

        public Command ChronicDiseasePopUp { get; set; }

        public Command PatientAnaylticsPortal { get; set; }

        public Command MedicalFilesNotePopUp { get; set; }

        public Command MedicationPopUp { get; set; }

        public Command AllergiesPopUp { get; set; }

        public Command AgePopUp { get; set; }

        public Command BloodTypePopUp { get; set; }

        public Command BloodPressurePopUp { get; set; }

        public Command GenderPopUp { get; set; }
        #endregion

        #region Methods
        //Note: For now all generate pop-up methods must use strings in messaging centers, some will use lists in the future

        //Will be used when the backend is configured, use the appropriate id argument needed to query mongodb
        private Patient GetBackendInformation(int patientId)
        {
            patientInfo = new Patient();

            return patientInfo;
        }

        private void GenerateGenderPopUp()
        {
            const string GenderArg = "Gender";

            MessagingCenter.Send<PatientDetailsViewModel, string>(this, MessagingKeys.UpperTilePopUp, GenderArg);

            PopupNavigation.Instance.PushAsync(upperTileMedicalDetails);
        }

        private void GenerateBloodPressurePopUp()
        {
            const string PressureArg = "Pressure";

            MessagingCenter.Send<PatientDetailsViewModel, string>(this, MessagingKeys.UpperTilePopUp, PressureArg);

            PopupNavigation.Instance.PushAsync(upperTileMedicalDetails);
        }

        private void GenerateBloodTypePopUp()
        {
            const string BloodTypeArg = "BloodType";

            MessagingCenter.Send<PatientDetailsViewModel, string>(this, MessagingKeys.UpperTilePopUp, BloodTypeArg);

            PopupNavigation.Instance.PushAsync(upperTileMedicalDetails);
        }

        private void GenerateAgePopUp()
        {
            const string AgeArg = "DOB";

            MessagingCenter.Send<PatientDetailsViewModel, string>(this, MessagingKeys.UpperTilePopUp, AgeArg);

            PopupNavigation.Instance.PushAsync(upperTileMedicalDetails);
        }

        private void GenerateMedicalFilesNotePopUp()
        {
            const string SomeArg = "X-Ray";

            //Send somthing via the messeging center
            MessagingCenter.Send<PatientDetailsViewModel, string>(this, MessagingKeys.MedicalDetails, SomeArg);

            PopupNavigation.Instance.PushAsync(tileMedicalDetailPopUp);
        }

        private void GenerateMedicationPopUp()
        {
            const string SomeArg2 = "Oxycon";

            MessagingCenter.Send<PatientDetailsViewModel, string>(this, MessagingKeys.MedicalDetails, SomeArg2);

            PopupNavigation.Instance.PushAsync(tileMedicalDetailPopUp);
        }

        private void GenerateAllergiesPopUp()
        {
            const string SomeArg3 = "SeaFood";

            MessagingCenter.Send<PatientDetailsViewModel, string>(this, MessagingKeys.MedicalDetails, SomeArg3);

            PopupNavigation.Instance.PushAsync(tileMedicalDetailPopUp);
        }

        private void GenerateChronicDiseasePopUp()
        {
            const string SomeArg4 = "Diabetestype2";

            MessagingCenter.Send<PatientDetailsViewModel, string>(this, MessagingKeys.MedicalDetails, SomeArg4);

            PopupNavigation.Instance.PushAsync(tileMedicalDetailPopUp);
        }

        private async void NavigateToPrescriptionForms()
        {
            RaiseButtonPressed();

            IsBusy = true;

            if(IsButtonEnabled.Equals(true))
            {
                IsButtonEnabled = false;

                try
                {
                    //Wait for the animation to finish then move to the next page
                    await Task.Delay(250);
                    await App.Current.MainPage.Navigation.PushAsync(new DoctorPrescription(), true);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    IsBusy = false;

                    IsButtonEnabled = true;
                }
            }

        }

        //Might have to be removed, to remove redundency in the application
        private async void NavigateToAddMedFiles()
        {
            IsBusy = true;

            IsButtonEnabled = false;

            if(IsButtonEnabled!=true)
            {

                try
                {
                    //Some code
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    IsBusy = false;

                    IsButtonEnabled = true;
                }
            }


        }

        private void PatientAnaylicsPopUpPage()
        {
            RaiseButtonPressed();

            IsBusy = true;

            IsButtonEnabled = false;

            if (IsButtonEnabled != true)
            {
                try
                {
                    //Get from back end .net machine learning api
                    PopupNavigation.Instance.PushAsync(analyticsPopUp);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    IsButtonEnabled = true;

                    IsBusy = false;
                }
            }

        }

        private void NavigateToDoctorsNote()
        {
            IsBusy = true;

            IsButtonEnabled = false;

            if (IsButtonEnabled!=true)
            {

                try
                {
                    PopupNavigation.Instance.PushAsync(notePop);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    IsBusy = false;

                    IsButtonEnabled = true;
                }
            }

        }
        #endregion
    }
}
