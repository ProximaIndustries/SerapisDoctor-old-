using MongoDB.Bson;
using SerapisDoctor.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Model.Doctor
{
    public class Doctor
    {
        public ObjectId UserId { get; set; }

        public DoctorUser User { get; set; }

        public Genders Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int YearsOfExp { get; set; }

        public string PhotoUrl { get; set; }

        public string Qualification { get; set; }

        public string VarsityAttended { get; set; }

        public Specilization Specialization { get; set; }

        public int NumOfPrescriptions { get; set; }

        public int NumOfPatientsSeen { get; set; }

        public DoctorPrescription prescription { get; set; }

        public DoctorsNote DoctorNote { get; set; }

    }
}
