using SerapisDoctor.Model;
using SerapisDoctor.Model.PatientModel;
using SerapisDoctor.Services;
using SerapisDoctor.Utils;
using SerapisDoctor.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel
{
    public class DiagnosisListViewModel
    {
        private uint lineNumber = 1;

        public ObservableCollection<PatientMeta> DiagnoseList { get; set; }
        

        public DiagnosisListViewModel()
        {
            InitailizeList();
        }


        private ObservableCollection<PatientMeta> InitailizeList()
        {
            DiagnoseList = new ObservableCollection<PatientMeta>();

            PatientMeta meta;

            foreach (var item in PatientsWaintingLineDb.GetPatientsAsync().Result)
            {
                meta = new PatientMeta()
                {
                    FullName = item.FullName,
                    ProfilePicture = item.ProfilePicture,
                    Appointment=item.Appointment,
                    LineNumber=lineNumber
                };

                lineNumber++;

                DiagnoseList.Add(meta);
            }

            return DiagnoseList;
        }

        public ICommand SelectPateintCommand => new Command<PatientMeta>(patientDetails=>
        {
            NavigateToDetails();

            //Use query to get details using the patients id.

            //Start the timer clock.
            AppointmentStopWatch.StartClockCount();
        });

        private void NavigateToDetails()
        {
            App.Current.MainPage.Navigation.PushAsync(new PatientDetails());
        }

    }
}
