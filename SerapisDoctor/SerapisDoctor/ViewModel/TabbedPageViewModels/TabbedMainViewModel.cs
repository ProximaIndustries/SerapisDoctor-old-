using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SerapisDoctor.Services.Data;
using SerapisDoctor.Services;
using System.IO;
using SerapisDoctor.Model.Practice;
using System.Json;
using Newtonsoft.Json;

namespace SerapisDoctor.ViewModel.TabbedPageViewModels
{
    public class TabbedMainViewModel
    {
        public TabbedMainViewModel()
        {
            testCommand = new Command(RunTest);
        }

        public Command testCommand { get; set; }

        private async void RunTest()
        {
            BookingApi apiCall = new BookingApi();

            string pathway = @"D:\Dummy Data\{0}";

            string filename = "PracticeInformation.json";

            pathway = String.Format(pathway, filename);

            PracticeInformation practice = new PracticeInformation() 
            { 
                 Id=MongoDB.Bson.ObjectId.Parse("5bc8e04a1c9d44000088ad93"),
                 PracticeName= "MediCross:Pinetown",
                 PracticeAddress=new Address() 
                 { 
                     AddressLineOne="",
                     AddressLineTwo="",
                     CityTown="",
                     PostalCode="3610"
                 },
                 Latitude= 73.436237534567,
                 Longitude= 54.34564326754,
                 DistanceFromPractice=20.3
            };

            try
            {
                
            }
            catch (Exception)
            {
                throw;
            }

            await apiCall.GetBookedPatientsAsync();

            await App.Current.MainPage.DisplayAlert("It worked", "Worked", "cancel");
        }
    }
}
