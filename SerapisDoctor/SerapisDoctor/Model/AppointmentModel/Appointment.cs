using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using SerapisDoctor.Model.Patient;
namespace SerapisDoctor.Model.AppointmentModel
{
    public class Appointment
    {
        public ObjectId BookingId { get; set; }
        public int LineNumber { get; set; }
        public string DateBooked { get; set; }
        public string TimeBooked { get; set; }
        public bool HasSeenGP { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public Patient.Patient PatientInformation { get; set; }
    }
}
