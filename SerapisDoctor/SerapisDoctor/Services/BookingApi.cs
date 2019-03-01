﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;
using SerapisDoctor.Model.Patient;
using System.Linq;
using System.IO;

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
        public async Task<IEnumerable<Patient>> GetBookedPatientsAsync()
        {

            List<Patient> storePatients = new List<Patient>();

            //The absolute path for the api
            var BookedPatients_Api_Path = "http://localhost:62575/api/{0}";

            try
            {

                BookedPatients_Api_Path = string.Format(BookedPatients_Api_Path, "booking");

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.BaseAddress = new Uri(BookedPatients_Api_Path);

                    var response = client.GetAsync(BookedPatients_Api_Path).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var listOfBookedPatients =await response.Content.ReadAsStringAsync();

                        var deseralizedList = JsonConvert.DeserializeObject<List<Patient>>(listOfBookedPatients).ToList();

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
        public async Task<Patient> GetPatientFileAsync(ObjectId _id)
        {
            if (_id != null)
            {
                var Patient_Api_Path = "http://localhost:62575/api/Patient/{0}";

                Patient_Api_Path = string.Format(Patient_Api_Path, _id);

                Patient _patientFile = new Patient();

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

                            var jsonFile = JsonConvert.DeserializeObject<Patient>(content);

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
