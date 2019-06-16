using SerapisDoctor.Model.PatientModel;
using SerapisDoctor.Services;
using SerapisDoctor.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel.TabbedPageViewModels
{
    public class CheckOutViewModel:BaseViewModel
    {

        public CheckOutViewModel()
        {
            InitalizeList();
        }

        private ObservableCollection<PatientMeta> list;
        public ObservableCollection<PatientMeta> List
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
            }
        }
        private ObservableCollection<PatientMeta> InitalizeList()
        {
            List = new ObservableCollection<PatientMeta>();

            foreach (var patient in PatientsWaintingLineDb.GetPatientsAsync().Result)
            {
                List.Add(patient);
            }

            return List;
        }

        private int lineNumber;
        public int LineNumber
        {
            get
            {
                return lineNumber;
            }
            set
            {
                lineNumber = value;
                OnPropertyChanged("LineNumber");
                lineNumber++;
            }
        }

        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

    }
}
