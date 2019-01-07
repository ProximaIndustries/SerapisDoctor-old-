using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SerapisDoctor.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {

        }


        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }

            set
            {

                isBusy = value;

                OnPropertyChanged("IsBusy");
            }
        }

        private bool isNotBusy;
        public bool IsNotBusy
        {
            get
            {
                return isNotBusy;
            }
            set
            {
                isNotBusy = value;
                OnPropertyChanged("IsNotBusy");
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = "")
        {
            if (propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
