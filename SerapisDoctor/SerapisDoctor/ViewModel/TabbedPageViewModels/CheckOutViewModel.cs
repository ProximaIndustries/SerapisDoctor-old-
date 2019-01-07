using SerapisDoctor.Model.Patient;
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

        private void InitalizeList()
        {
            List = new ObservableCollection<Patient>();
            List = PatientsInLine._list;
        }

        private ObservableCollection<Patient> _list;
        public  ObservableCollection<Patient> List
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
            }
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
