using SerapisDoctor.Model.Doctor;
using SerapisDoctor.Model.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SerapisDoctor.Services
{
    public class DoctorLocationTracker
    {
        //This is used locally to get the doctors location
        private static Location LocalGpsCoordinate { get; set; }

        public DoctorLocationTracker()
        {
            GeolocationRequest location = new GeolocationRequest();
            location.DesiredAccuracy = GeolocationAccuracy.Medium;
            location.Timeout = TimeSpan.FromMinutes(1);
            GetCurrentLocationAsync();
        }

        public async Task<Location> GetCurrentLocationAsync()
        {
            LocalGpsCoordinate = await Geolocation.GetLastKnownLocationAsync();
            return LocalGpsCoordinate;
        }

        //Calculate from the gps co-ordinates where the doctor possibly is at
        public PracticeInformation GetPossibleCurrentPractice(List<PracticeInformation> listOfPractices)
        {

            foreach (var practice in listOfPractices)
            {
                //calculate the distance for each and set that value
                //practice.DistanceFromPractice = 
                //    CalculateDistance
                //    (GetCurrentLocation().Latitude, 
                //    GetCurrentLocation().Longitude, 
                //    practice.Latitude, practice.Longitude
                //    );
            }

            //Then order the list that was entred
            var result=listOfPractices.OrderBy(i => i.DistanceFromPractice).FirstOrDefault();

            //Temporary return of null
            return result;
        }

        //To clean the code up, another method is used 
        private double CalculateDistance(double currentLati, double currentLongi, double practiceLati, double practiceLongi)
        {
            var distance = Location.CalculateDistance(currentLati, currentLongi, practiceLati, practiceLongi, DistanceUnits.Kilometers);

            return distance;
        }

        //Need to add chaging location code here

    }
}
