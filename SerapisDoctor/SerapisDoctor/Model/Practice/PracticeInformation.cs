﻿using MongoDB.Bson;
using System.Collections.Generic;

namespace SerapisDoctor.Model.Practice
{
    public class PracticeInformation
    {

        public ObjectId Id { get; set; }

        public string PracticePicture { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string PracticeName { get; set; }

        public Address PracticeAddress { get; set; }

        public double DistanceFromPractice { get; set; }

        public string OperatingTime { get; set; }

        public int NumOfPatientsInPractice { get; set; }

        public PracticeContact ContactPractice { get; set; }

        public List<ObjectId> DoctorsAtPractice{get; set;}
    }

}
