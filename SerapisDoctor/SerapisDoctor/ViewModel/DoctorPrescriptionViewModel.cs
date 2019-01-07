using SerapisDoctor.Global_Lists;
using SerapisDoctor.Model.Doctor;
using SerapisDoctor.Utils;
using SerapisDoctor.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel
{
    public class DoctorPrescriptionViewModel:BaseViewModel
    {
        Model.Doctor.DoctorPrescription prescription;

        private ObservableCollection<Model.Doctor.DoctorPrescription> PrescriptionScriptList { get; set; }

        public DoctorPrescriptionViewModel()
        {
            PrescriptionScriptList = new ObservableCollection<Model.Doctor.DoctorPrescription>();
            AddToBusketCommand = new Command(AddMedication);
            ViewBusketCommand = new Command(NavigateToConfirmationPage);
        }

        #region Command Properties
        public ICommand ViewBusketCommand { get; set; }

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
                //Value for now 
                return setOpacity;
            }
            set
            {
                setOpacity = value;
                OnPropertyChanged("SetOpacity");
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

        private async void NavigateToConfirmationPage()
        {
            MessagingCenter.Send(this, MessagingKeys.PrescriptionMsg, PrescriptionScriptList);
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
                TypeOfMedication=MedicationType.bandage
            };

            try
            {
                if (CheckEntryFields() == true)
                {
                    PrescriptionScriptList.Add(prescription);
                    CountBusketItems();
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

        private int CountBusketItems()
        {
            return MedsInBusket = PrescriptionScriptList.Count;
        }

    }
}
