using SerapisDoctor.Global_Lists;
using SerapisDoctor.Model.Patient;
using SerapisDoctor.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel
{
    public class PatientInWaitingViewModel:BaseViewModel
    {
        Patient patientObj = new Patient();
        public PatientInWaitingViewModel()
        {
            TempButtonCommand = new Command(Navigate);
            InitializeList();
        }

        private ObservableCollection<Patient> diagnoseList;
        public ObservableCollection<Patient> DiagnosisList
        {
            get
            {
                return diagnoseList;
            }
            set
            {
                diagnoseList = value;
                PatientsInLine.UpdateList();
            }
        }

        public Command TempButtonCommand { get; set; }

        public ICommand SelectPatientCommand => new Command<Patient>(patientDetails => 
        {
               Navigate();
        });

        private void InitializeList()
        {
            DiagnosisList = new ObservableCollection<Patient>();
            DiagnosisList = PatientsInLine._list;
        }

        private async void Navigate()
        {
           await App.Current.MainPage.Navigation.PushAsync(new PatientDetails());
        }


    }
}
