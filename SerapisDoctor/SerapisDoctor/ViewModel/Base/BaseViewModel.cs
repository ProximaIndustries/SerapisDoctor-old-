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

        private bool isButtonEnabled;

        public bool IsButtonEnabled
        {
            get
            {
                return isButtonEnabled;
            }
            set
            {
                isButtonEnabled = value;
                OnPropertyChanged("IsButtonEnabled");
                IsButtonEnabled = value;
            }
        }


        private bool isRefreshing;

        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
                isRefreshing = value;
            }
        }


        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }

            set
            {

                isBusy = value;

                OnPropertyChanged("IsBusy");

                isBusy = value;
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
