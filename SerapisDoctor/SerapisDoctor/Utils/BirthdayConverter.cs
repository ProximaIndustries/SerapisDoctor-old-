using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Utils
{
    public class BirthdayConverter
    {
        DateTime today = new DateTime(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);

       // DateTime dobTest = new DateTime(DateTime.Parse("20 March 1996"));

        public void CalculateAge(DateTime Dob)
        {
            TimeSpan ageValue;

           ageValue= today - Dob;
        }

    }
}
