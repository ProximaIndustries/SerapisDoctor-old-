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
        //Get all booked patients for the day
         Task<IEnumerable<Patient>> GetBookedPatientsAsync();

        //Get the patients full details
         Task<Patient> GetPatientFileAsync(ObjectId patientInfomation);

        //Check Them out the practice
         Task CheckPatientOutAsync(ObjectId id);
    }
}
