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
            Lati = Geolocation.GetLastKnownLocationAsync().Result.Latitude.ToString();

            Longi = Geolocation.GetLastKnownLocationAsync().Result.Longitude.ToString();
        }

        public string Lati { get; set; } = "";

        public string Longi { get; set; } = "";
    }
}
