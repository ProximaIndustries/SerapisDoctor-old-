using MongoDB.Bson;
using SerapisDoctor.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SerapisDoctor.Services
{
    interface IApiBookedCommands
    {
         Task<List<Patient>> GetBookedPatientsAsync();
         Task GetPatientFileAsync(ObjectId id, Patient patientInfomation);
         Task CheckPatientOutAsync(ObjectId id);
    }
}
