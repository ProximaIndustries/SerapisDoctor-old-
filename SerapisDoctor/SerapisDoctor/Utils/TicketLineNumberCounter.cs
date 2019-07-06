using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Utils
{
    //This class keeps track of patients checked in and what number they are
    public static class TicketLineNumberCounter
    {
        public static uint PatientLineNumber=1;

        public static uint IncrementLineNumber()
        {
            return PatientLineNumber++;
        }

        //Incase mistakes were made, a method to alternate the input
        public static uint DecremenetLineNumber()
        {
            if (PatientLineNumber != 0)
            {
                return PatientLineNumber--;
            }
            else
            {
                return PatientLineNumber = 1;
            }
        }

        //Change a particular Patients line number, object id is the Sql local db id number
        public static void ChanagePatientsLineNumber(object id, uint lineNumber)
        {
            //1.Check if it matches the Sql local db id first

            //2.Call the Services.PatientsWaintingLineDb static class and change the line number
        }
    }
}
