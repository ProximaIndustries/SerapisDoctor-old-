﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Model.MedicalDetails
{
    public class Medication
    {
        public ObjectId DrugCode { get; set; }
        public string Dosage { get; set; }
        public string MedicationName { get; set; }
        public string CompanyName { get; set; }
        public string BrandName { get; set; }
    }
}
