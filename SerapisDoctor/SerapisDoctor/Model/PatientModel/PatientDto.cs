using MongoDB.Bson;
using SerapisDoctor.Model.AppointmentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Model.PatientModel
{
    public class PatientDto
    {
        public ObjectId PatientId { get; set; }

        public string ProfilePicture { get; set; }

        public bool MedicalAidPatient { get; set; }

        public AppointmentDto AppointmentSet { get; set; }

        public string FullName { get; set; }
    }
}
