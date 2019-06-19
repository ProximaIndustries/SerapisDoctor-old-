using SerapisDoctor.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SerapisDoctor.ViewModel.SideMenuPageViewModel
{
    public class HelpViewModel
    {
        public HelpViewModel()
        {
            Initalize();
        }

        private void Initalize()
        {
            DoctorLocationTracker tracker = new DoctorLocationTracker();

            Lati = tracker.GetCurrentLocationAsync().Result.Latitude.ToString();

            Longi = tracker.GetCurrentLocationAsync().Result.Longitude.ToString();
        }

        public string Lati { get; set; } = "";

        public string Longi { get; set; } = "";
    }
}
