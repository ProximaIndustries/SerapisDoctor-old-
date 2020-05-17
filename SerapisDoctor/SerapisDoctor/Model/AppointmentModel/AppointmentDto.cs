using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Model.AppointmentModel
{
    public class AppointmentDto
    {
        public ObjectId AppointmentId { get; set; }

        public DateTime DateBooked { get; set; }

        public DateTime TimeBooked { get; set; }
    }
}
