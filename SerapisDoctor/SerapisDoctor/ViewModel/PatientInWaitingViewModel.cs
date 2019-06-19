using SerapisDoctor.Global_Lists;
using SerapisDoctor.Model.PatientModel;
using SerapisDoctor.Services;
using SerapisDoctor.View;
using SerapisDoctor.ViewModel.TabbedPageViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel
{
    public class PatientInWaitingViewModel:BaseViewModel
    {
        PatientMeta patientObj = new PatientMeta();
        public PatientInWaitingViewModel()
        {
            InitializeList();
            TempButtonCommand = new Command(Navigate);
        }

        
        public ObservableCollection<PatientMeta> DiagnoseList { get; set; }
        

        public Command TempButtonCommand { get; set; }

        public ICommand SelectPatientCommand => new Command<PatientMeta>(patientDetails => 
        {
            IsBusy = true;

            try
            {
                Navigate();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                IsBusy = false;
            }
        });

        public ICommand TestBehav => new Command<PatientMeta>(patientDetails => 
        {
            IsBusy = true;

            try
            {
                //Request to get the patients details in the backend using the mongodbId

            }
            catch (Exception)
            {

                throw;
            }
        });

        private void InitializeList()
        {
            DiagnoseList = new ObservableCollection<PatientMeta>();

            //Get the meta data from the patient local database
        }

        private async void Navigate()
        {
           await App.Current.MainPage.Navigation.PushAsync(new PatientDetails());
        }

    }
}
