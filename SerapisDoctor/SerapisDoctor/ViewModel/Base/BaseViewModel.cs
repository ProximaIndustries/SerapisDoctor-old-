using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace SerapisDoctor.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        private bool isButtonEnabled=true;

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
                isButtonEnabled = value;
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


        private string title;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
                title = value;
            }
        }


        private string  imageIcon;

        public string ImageIcon
        {
            get
            {
                return imageIcon;
            }
            set
            {
                imageIcon = value;
                OnPropertyChanged("ImageIcon");
                imageIcon = value;
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
