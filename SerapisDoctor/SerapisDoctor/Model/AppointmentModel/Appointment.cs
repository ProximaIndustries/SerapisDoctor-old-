using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using SerapisDoctor.Model.PatientModel;
using Microsoft.Graph;
using SerapisDoctor.Model.Practice;

namespace SerapisDoctor.Model.AppointmentModel
{
    public class Appointment
    {
        
        public ObjectId BookingId { get; set; }
        public int LineNumber { get; set; }
        public DateTime DateBooked { get; set; }
        public DateTime TimeBooked { get; set; }
        public bool HasSeenGP { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsSerapisBooking { get; set; }
        public bool HasBeenToThisPractice { get; set; }

        public Address PracticeAddress { get; set; }

        public ObjectId DoctorsId { get; set; }
    }
}
