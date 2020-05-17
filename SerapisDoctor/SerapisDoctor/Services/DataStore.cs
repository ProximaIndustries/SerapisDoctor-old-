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
            IsDependent = false,
            IsMedicalAidPatient=false
        };

        static PatientMeta Patient2 = new PatientMeta()
        {
           ProfilePicture="Bonga.jpeg",
           FullName="Bonga Ngcobo",
           IsDependent=false,
           IsMedicalAidPatient=false
        };

        static PatientMeta Patient3 = new PatientMeta()
        {
            ProfilePicture = "randomLady.png",
            FullName = "Alex Smith",
            IsDependent = true,
            IsMedicalAidPatient = true
        };

        static PatientMeta PatientRefresher = new PatientMeta()
        {
            ProfilePicture = "userplaceholder.png",
            FullName = "Robin Van Zyl",
            IsDependent = true,
            IsMedicalAidPatient = false
        };

        static PatientMeta Patient4 = new PatientMeta()
        {
            ProfilePicture= "wthenjwayo.jpg",
            FullName="Wandile Thenjwayo",
            IsDependent=false,
            IsMedicalAidPatient=true
        };

        static List<PatientMeta> BookedPatientsToday = new List<PatientMeta>();

        public static List<PatientMeta> GetBookedPatients()
        {
            BookedPatientsToday.Add(Patient3);
            BookedPatientsToday.Add(Patient);
            BookedPatientsToday.Add(Patient2);
            BookedPatientsToday.Add(Patient4);

            return BookedPatientsToday;
        }

        public static PatientMeta GetRefereshedBookedPatients()
        {
            return PatientRefresher;
        }
    }
}
