using SerapisDoctor.Model.AppointmentModel;
using SerapisDoctor.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Services
{
    public static class DataStore
    {
        static PatientMeta Patient = new PatientMeta()
        {
            ProfilePicture = "Capture.png",
            FullName = "Khanyisani Buthelezi",
        };

        static PatientMeta Patient2 = new PatientMeta()
        {
           ProfilePicture="Bonga.jpeg",
           FullName="Bonga Ngcobo"
        };

        static PatientMeta Patient3 = new PatientMeta()
        {
            ProfilePicture="userplaceholder.png",
            FullName="Anderson Cooper"
        };

        static List<PatientMeta> BookedPatientsToday = new List<PatientMeta>();

        public static List<PatientMeta> GetBookedPatients()
        {
            BookedPatientsToday.Add(Patient);
            BookedPatientsToday.Add(Patient2);

            return BookedPatientsToday;
        }

        public static PatientMeta GetRefereshedBookedPatients()
        {
            return Patient3;
        }
    }
}
