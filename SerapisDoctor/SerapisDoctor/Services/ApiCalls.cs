using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using SerapisDoctor.Model.Patient;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson;

namespace SerapisDoctor.Services
{
    public class ApiCalls:IApiBookedCommands
    {
        private HttpClient client;

        public ApiCalls()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.BaseAddress = new Uri("http://localhost:57015/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task CheckPatientOutAsync(ObjectId id)
        {
            var uri = new Uri(string.Format(@"/api/BookedPatients/{0}", id));

            var response = await client.DeleteAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                //some succes code
            }
            else
            {
                //there was  a problem with the request
            }
        }

        public async Task<List<Patient>> GetBookedPatientsAsync()
        {
            List<Patient> storePatients = new List<Patient>();

            Uri uri = new Uri(client.BaseAddress.OriginalString + "api/BookedPatients");

            HttpResponseMessage response =await client.GetAsync(uri);


            if (response.IsSuccessStatusCode)
            {
                var patients =await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<Patient>>(patients);

                foreach (var item in Items)
                {
                    storePatients.Add(item);
                }
            }
            else
            {
                //some error
            }

            return storePatients;
        }

        public async Task GetPatientFileAsync(ObjectId id, Patient patientInfomation)
        {
            Uri uri = new Uri(string.Format(@"/api/BookedPatients/{0}", id));

            var response =await client.GetAsync(uri);

            Patient moreInformation;

            if (response.IsSuccessStatusCode)
            {
                
                if (id == patientInfomation.Id)
                {
                    //Get Medical files
                }
                else
                {
                    //return an error
                }
            }
        }
    }
}
