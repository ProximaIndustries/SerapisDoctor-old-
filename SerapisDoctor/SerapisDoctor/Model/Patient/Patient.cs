using MongoDB.Bson;
using SerapisDoctor.Model.AppointmentModel;
using SerapisDoctor.Model.Enum;
using SerapisDoctor.Model.MedicalDetails;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Model.Patient
{
    public class Patient
    {
        public ObjectId Id { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientMedicalAid { get; set; }
        public bool MedicalAidPatient { get; set; }
        public string PatientBloodType { get; set; }
        public int PatientAge { get; set; }
        public bool HasBloodPressure { get; set; }
        public bool IsDepenedent { get; set; }
        public List<ChronicDisease> ListOfChronicDisease { get; set; }
        public List<Medication> ListOfMedication { get; set; }
        public List<Allergies> ListOfAllergies { get; set; }
        public List<MedicalFile> MedicalRecords { get; set; }
        public string PatientProfilePicture { get; set; }
        public Genders Gender { get; set; }
        public string FullName { get; set; }
        public Appointment Appointment { get; set; }
    }
}
