using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SerapisDoctor.Services
{
    public class ConnectionCheck
    {
        private dynamic currentState = Connectivity.NetworkAccess;

        public ConnectionCheck()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        //desconstructor
        ~ConnectionCheck()
        {
            Connectivity.ConnectivityChanged -= Unsubcribe;
        }

        private void Unsubcribe(object sender, ConnectivityChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #region Methods
        public bool CheckConnection()
        {
            //Savae the state first
            currentState = NetworkAccess.Internet;

            if (currentState == NetworkAccess.Internet)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var access = e.NetworkAccess;
        }

        #endregion
    }
}
