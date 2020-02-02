using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Linq;
using SerapisDoctor.Model.PatientModel;

namespace SerapisDoctor.Services
{
    public class BookingApi : IApiBookedCommands
    {
        
        public BookingApi()
        {
            
        }

        public async Task CheckPatientOutAsync(ObjectId id)
        {
           
        }

        //Gets all the patients booked for the day
        public async Task<IEnumerable<PatientMeta>> GetBookedPatientsAsync()
        {

            List<PatientMeta> storePatients = new List<PatientMeta>();

            //The absolute path for the api
            var BookedPatients_Api_Path = "http://serapismedicalapi.herokuapp.com/api/practice/{0}";
            //http://serapismedicalapi.herokuapp.com/api/practice
            //Make the default practice : "MediCross:Malvern"
            //id: 5bc9bd741c9d4400001badf0
            string dummy = "5bc9bd741c9d4400001badf0";
            string dummyTwo = "5bc9bd861c9d4400001badf1";
            try
            {

                BookedPatients_Api_Path = string.Format(BookedPatients_Api_Path, dummyTwo);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.BaseAddress = new Uri(BookedPatients_Api_Path);

                    var response = client.GetAsync(BookedPatients_Api_Path).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var listOfBookedPatients =await response.Content.ReadAsStringAsync();

                        var deseralizedList = JsonConvert.DeserializeObject<List<PatientMeta>>(listOfBookedPatients).ToList();

                        foreach (var patient in deseralizedList)
                        {
                            storePatients.Add(patient);
                        }

                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                //send diagnostics
                string error=ex.Message;
            }

            return storePatients;
        }


        //Get the patients medical information
        public async Task<PatientMeta> GetPatientFileAsync(ObjectId _id)
        {
            if (_id != null)
            {
                var Patient_Api_Path = "http://localhost:62575/api/Patient/{0}";

                Patient_Api_Path = string.Format(Patient_Api_Path, _id);

                PatientMeta _patientFile = new PatientMeta();

                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();

                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        client.BaseAddress = new Uri(Patient_Api_Path);

                        HttpResponseMessage response = client.GetAsync(Patient_Api_Path).GetAwaiter().GetResult();

                        if (response.IsSuccessStatusCode)
                        {
                            var content = response.Content.ReadAsStringAsync().Result;

                            var jsonFile = JsonConvert.DeserializeObject<PatientMeta>(content);

                            _patientFile = jsonFile;

                            return _patientFile;
                        }
                        else
                        {
                            return null;
                        }

                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }

    }

}

