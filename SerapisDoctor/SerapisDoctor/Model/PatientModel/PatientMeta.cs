using SerapisDoctor.Model.AppointmentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Model.PatientModel
{
    public class PatientMeta
    {
        [PrimaryKey, AutoIncrement]
        public int LocalId { get; set; }

        //Mongodb id
        public string Id { get; set; }

        public string FullName { get; set; }

        public string ProfilePicture { get; set; }

        public uint LineNumber { get; set; }

        public bool IsMedicalAidPatient { get; set; }

        [Ignore]
        public Appointment Appointment { get; set; }
    }
}
