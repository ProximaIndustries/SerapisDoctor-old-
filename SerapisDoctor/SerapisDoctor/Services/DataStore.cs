using SerapisDoctor.Model.AppointmentModel;
using SerapisDoctor.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Services
{
    public static class DataStore
    {
        static Patient Patient = new Patient()
        {
            PatientProfilePicture = "Capture.png",
            FullName = "Khanyisani Buthelezi",
            Gender = Model.Enum.Genders.male,
            HasBloodPressure = false,
            IsDepenedent = false,
            ListOfAllergies = null,
            MedicalAidPatient = true,
            PatientAge = 22,
            Appointment = new Appointment
            {
                DateBooked = DateTime.Today.ToShortDateString(),
                TimeBooked = DateTime.Today.ToShortTimeString()
            }
        };

        static Patient Patient2 = new Patient()
        {
            PatientProfilePicture = "userplaceholder.png",
            FullName = "Bonga Ngcobo",
            Gender = Model.Enum.Genders.male,
            HasBloodPressure = false,
            IsDepenedent = false,
            ListOfAllergies = null,
            MedicalAidPatient = false,
            PatientAge = 21,
            Appointment = new Appointment
            {
                DateBooked = DateTime.Today.ToShortDateString(),
                TimeBooked = DateTime.Today.AddMinutes(45).ToShortTimeString()
            }
        };

        static Patient Patient3 = new Patient()
        {
            PatientProfilePicture = "userplaceholder.png",
            FullName = "Anderson Cooper",
            Gender = Model.Enum.Genders.male,
            HasBloodPressure = false,
            IsDepenedent = false,
            ListOfAllergies = null,
            MedicalAidPatient = true,
            PatientAge = 45,
            Appointment = new Appointment
            {
                DateBooked = DateTime.Today.ToShortDateString(),
                TimeBooked = DateTime.Today.ToShortTimeString()
            }
        };

        static List<Patient> BookedPatientsToday = new List<Patient>();

        public static List<Patient> GetBookedPatients()
        {
            BookedPatientsToday.Add(Patient);
            BookedPatientsToday.Add(Patient2);

            return BookedPatientsToday;
        }

        public static Patient GetRefereshedBookedPatients()
        {
            return Patient3;
        }
    }
}
