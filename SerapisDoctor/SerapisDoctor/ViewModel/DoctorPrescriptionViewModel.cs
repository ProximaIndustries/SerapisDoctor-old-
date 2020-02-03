using SerapisDoctor.Model.Enum;
using SerapisDoctor.Services;
using SerapisDoctor.View;
using SerapisDoctor.View.Pop_ups;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;

namespace SerapisDoctor.ViewModel
{
    public class DoctorPrescriptionViewModel:BaseViewModel
    {
        #region Local event handler
        public delegate void ButtonPressedHandeler(object sender, EventArgs args);

        public event ButtonPressedHandeler ButtonEvent;

        public void RaiseButtonEvent()
        {
            if (ButtonEvent != null)
                ButtonEvent(this, new EventArgs());
        }
        #endregion

        private Model.Doctor.DoctorPrescription prescription;

        private MedicationTypePopUp PopUp;

        private ObservableCollection<Model.Doctor.DoctorPrescription> PrescriptionScriptList { get; set; }

        public DoctorPrescriptionViewModel()
        {
            PopUp = new MedicationTypePopUp();
            AddToBusketCommand = new Command(AddMedication);
            ViewBusketCommand = new Command(async()=>await NavigateToConfirmationPageAsync());
            DiffrentMedcationTypeForm = new Command(LoadPopUpPage);
        }

        #region Command Properties
        public ICommand ViewBusketCommand { get; set; }

        public ICommand DiffrentMedcationTypeForm { get; set; }

        public ICommand AddToBusketCommand { get; set; }
        #endregion


        #region Properties
        private string dosagePrescriptionAmount;
        public string DosagePrescriptionAmount
        {
            get
            {
                return dosagePrescriptionAmount;
            }
            set
            {
                dosagePrescriptionAmount = value;
                OnPropertyChanged("DosagePrescriptionAmount");
                dosagePrescriptionAmount = value;
            }
        }

        private string prescriptionInstructions;
        public string PrescriptionInstructions
        {
            get
            {
                return prescriptionInstructions;
            }
            set
            {
                prescriptionInstructions = value;
                OnPropertyChanged("PrescriptionInstructions");
                prescriptionInstructions = value;
            }
        }

        private string prescriptionMedication;
        public string PrescriptionMedication
        {
            get
            {
                return prescriptionMedication;
            }
            set
            {
                prescriptionMedication = value;
                OnPropertyChanged("PrescriptionMedication");
                prescriptionMedication = value;
            }
        }

        private string addedPrescriptionNotes;
        public string AddedPrescriptionNotes
        {
            get
            {
                return addedPrescriptionNotes;
            }
            set
            {
                addedPrescriptionNotes = value;
                OnPropertyChanged("AddedPrescriptionNotes");
                addedPrescriptionNotes = value;
            }
        }

        private int medsInBusket = 0;
        public int MedsInBusket
        {
            get
            {
                return medsInBusket;
            }
            set
            {
                medsInBusket = value;
                OnPropertyChanged("MedsInBusket");
                medsInBusket = value;
            }
        }

        private double setOpacity= 1;
        public double SetOpacity
        {
            get
            {
                return setOpacity;
            }
            set
            {
                setOpacity = value;
                OnPropertyChanged("SetOpacity");
                setOpacity = value;
            }
        }

        private MedicationType medType;
        public MedicationType MedType
        {
            get
            {
                return medType;
            }
            set
            {
                medType = value;
            }
        }


        #endregion

        private void LoadPopUpPage()
        {
            //This loads a pop up page with options on the diffrent medication types
            PopupNavigation.Instance.PushAsync(PopUp);
        }

        private async Task NavigateToConfirmationPageAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new BasketView());
        }

        private void AddMedication()
        {

            prescription = new Model.Doctor.DoctorPrescription()
            {
                PrescriptionDosage = DosagePrescriptionAmount,
                PrescriptionInstructions = PrescriptionInstructions,
                PrescriptionMedication = PrescriptionMedication,
                AddedPrescriptionNotes = AddedPrescriptionNotes,
                TypeOfMedication = MedicationType.pills,
                MedCashPrice = 30.45
            };

            try
            {
                if(CheckEntryFields() == true)
                {
                    RaiseButtonEvent();
                    PrescriptionLocalDb.InsertPrescription(prescription);
                    MedsInBusket = PrescriptionLocalDb.GetAllDoctorPrescriptionsAsync().Result.Count;
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Empty field detected", "There seems to be an error", "Try again");
                }
            }
            catch
            {

            }
            finally
            {
                ClearFields();
            }

        }

        private void ClearFields()
        {
            DosagePrescriptionAmount = string.Empty;
            PrescriptionInstructions = string.Empty;
            PrescriptionMedication = string.Empty;
            AddedPrescriptionNotes = string.Empty;
        }

        private bool CheckEntryFields()
        {
            bool checkDosageField =
                string.IsNullOrEmpty(DosagePrescriptionAmount);

            bool checkMedicationField =
                string.IsNullOrEmpty(PrescriptionMedication);

            bool checkInstructions =
                string.IsNullOrEmpty(PrescriptionInstructions);


            if (checkMedicationField || checkInstructions || checkDosageField)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
