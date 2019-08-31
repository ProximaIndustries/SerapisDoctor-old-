using SerapisDoctor.Services;
using SerapisDoctor.View;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;

namespace SerapisDoctor.ViewModel
{
    public class BusketViewViewModel:BaseViewModel
    {
        #region Local events
        public delegate void ButtonPressed(object sender, EventArgs args);

        public event ButtonPressed ButtonEvent;

        public void RaiseButtonPressed()
        {
            if (ButtonEvent != null)
                ButtonEvent(this,new EventArgs());
        }
        #endregion

        public BusketViewViewModel()
        {
            ConfirmCommand = new Command(NavigateToConfirmationPage);
            RemoveItem = new Command(DeletePrescription);
            InitalizeList();
        }

        public Command ConfirmCommand { get; set; }

        public Command RemoveItem { get; set; }

        private ObservableCollection<Model.Doctor.DoctorPrescription> prescriptionList;
        public ObservableCollection<Model.Doctor.DoctorPrescription> PrescriptionList
        {
            get
            {
                return prescriptionList;
            }
            set
            {
                prescriptionList = value;
            }
        }

        private bool labelVisibility=false;

        public bool LabelVisibility
        {
            get
            {
                return labelVisibility;
            }
            set
            {
                labelVisibility = value;
                OnPropertyChanged("LabelVisibility");
                if (PrescriptionLocalDb.GetAllDoctorPrescriptionsAsync().Result.Count >0)
                {
                    labelVisibility = true;
                }
            }
        }

        private int numOfItems=PrescriptionLocalDb.GetAllDoctorPrescriptionsAsync().Result.Count;
        public int NumOfItems
        {
            get
            {
                return numOfItems;
            }
            set
            {
                numOfItems = value;
                OnPropertyChanged("NumOfItems");
                numOfItems=value;
            }
        }

        private void DeletePrescription()
        {
            
        }

        private async void NavigateToConfirmationPage()
        {
            RaiseButtonPressed();
            await Task.Delay(100);
            await App.Current.MainPage.Navigation.PushAsync(new ConfirmationPage());
        }

        private void InitalizeList()
        {
            PrescriptionList = new ObservableCollection<Model.Doctor.DoctorPrescription>();

            foreach (var medication in PrescriptionLocalDb.GetAllDoctorPrescriptionsAsync().Result)
            {
                PrescriptionList.Add(medication);
            }

        }
    }
}
