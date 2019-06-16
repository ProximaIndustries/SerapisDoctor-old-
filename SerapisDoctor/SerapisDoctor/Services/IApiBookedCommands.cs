using MongoDB.Bson;
using SerapisDoctor.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SerapisDoctor.Services
{
    interface IApiBookedCommands
    {
        //Get all booked patients for the day
         Task<IEnumerable<PatientMeta>> GetBookedPatientsAsync();

        //Get the patients full details
         Task<PatientMeta> GetPatientFileAsync(ObjectId patientInfomation);

        //Check Them out the practice
         Task CheckPatientOutAsync(ObjectId id);
    }
}
