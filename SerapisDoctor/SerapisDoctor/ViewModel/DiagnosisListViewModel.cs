using SerapisDoctor.Model;
using SerapisDoctor.Model.PatientModel;
using SerapisDoctor.Services;
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
                    ProfilePicture = item.ProfilePicture
                };

                DiagnoseList.Add(meta);
            }

            return DiagnoseList;
        }

        public ICommand SelectPateintCommand => new Command<PatientMeta>(patientDetails=>
        {
            NavigateToDetails();
        });

        private void NavigateToDetails()
        {
            App.Current.MainPage.Navigation.PushAsync(new PatientDetails());
        }

    }
}
