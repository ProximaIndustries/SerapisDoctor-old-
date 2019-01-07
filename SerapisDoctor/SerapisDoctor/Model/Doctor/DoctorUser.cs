using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Model.Doctor
{
    public class DoctorUser
    {
        //login and sign up properties

        public string Password { get; set; }
        public string Email { get; set; }
        public string GivenCode { get; set; }
        public string LastLogin { get; set; }
        public bool HasbeenValidated { get; set; }
        
    }
}
