using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using SerapisDoctor.Model.PatientModel;
namespace SerapisDoctor.Model.AppointmentModel
{
    public class Appointment
    {
        public ObjectId BookingId { get; set; }
        public int LineNumber { get; set; }
        public string DateBooked { get; set; }
        public string TimeBooked { get; set; }
        public bool HasSeenGP { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
