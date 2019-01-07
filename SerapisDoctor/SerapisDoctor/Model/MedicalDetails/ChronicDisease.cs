using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Model.MedicalDetails
{
    public class ChronicDisease
    {
        public ObjectId Id { get; set; }
        public string ChronicDiseaseName { get; set; }
    }
}
