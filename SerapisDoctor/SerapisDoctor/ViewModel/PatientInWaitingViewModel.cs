using SerapisDoctor.Global_Lists;
using SerapisDoctor.Model.Patient;
using SerapisDoctor.Services;
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

        public ObservableCollection<PateintMeta> DiagnoseList { get; set; }
        

        public Command TempButtonCommand { get; set; }

        public ICommand SelectPatientCommand => new Command<Patient>(patientDetails => 
        {
               Navigate();
        });

        private void InitializeList()
        {
            DiagnoseList = new ObservableCollection<PateintMeta>();

            //Get the meta data from the patient local database
            foreach (var patientInWaiting in PatientsWaintingLineDb.GetPatientsAsync().Result)
            {
                DiagnoseList.Add(patientInWaiting);
            }
        }

        private async void Navigate()
        {
           await App.Current.MainPage.Navigation.PushAsync(new PatientDetails());
        }

    }
}
