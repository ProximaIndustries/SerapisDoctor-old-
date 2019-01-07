using SerapisDoctor.Global_Lists;
using SerapisDoctor.Model.Doctor;
using SerapisDoctor.Utils;
using SerapisDoctor.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel
{
    public class BusketViewViewModel:BaseViewModel
    {
      
        public BusketViewViewModel()
        {
            ConfirmCommand = new Command(NavigateToConfirmationPage);
            InitializeList();
        }

        public Command ConfirmCommand { get; set; }

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


        private int numOfItems;
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
                numOfItems=CountItems();
            }
        }

        private int CountItems()
        {
            return PrescriptionList.Count;
        }

        private void InitializeList()
        {
            PrescriptionList = new ObservableCollection<Model.Doctor.DoctorPrescription>();

            MessagingCenter.Subscribe<DoctorPrescriptionViewModel, ObservableCollection<Model.Doctor.DoctorPrescription>>(this, MessagingKeys.PrescriptionMsg, (obj, sender) =>
            {
                PrescriptionList = sender;
            });
        }

        private async void NavigateToConfirmationPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ConfirmationPage());
        }
    }
}
