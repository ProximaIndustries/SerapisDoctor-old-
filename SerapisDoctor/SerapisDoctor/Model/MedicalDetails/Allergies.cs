using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Model.MedicalDetails
{
    public class Allergies
    {
        public ObjectId Id { get; set; }
        public string AllergyName { get; set; }
    }
}
