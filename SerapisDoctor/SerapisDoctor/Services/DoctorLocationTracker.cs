using SerapisDoctor.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SerapisDoctor.Services
{
    public class DoctorLocationTracker
    {
        public DoctorLocationTracker()
        {
            
        }

        private void GetDoctorsCurrentLocation()
        {
            Geolocation.GetLocationAsync();
        }

        //Calculate from the gps co-ordinates where the doctor possibly is at
        private void GetPossibleCurrentPractice(List<DoctorUser>)
        {

        }
    }
}
