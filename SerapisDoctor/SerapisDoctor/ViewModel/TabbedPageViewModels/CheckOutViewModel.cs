using SerapisDoctor.Model.PatientModel;
using SerapisDoctor.Services;
using SerapisDoctor.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel.TabbedPageViewModels
{
    public class CheckOutViewModel:BaseViewModel
    {

        public CheckOutViewModel()
        {
            InitalizeList();
        }

        public ObservableCollection<PatientMeta> List { get; set; }

        private void InitalizeList()
        {
            List = new ObservableCollection<PatientMeta>();

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
