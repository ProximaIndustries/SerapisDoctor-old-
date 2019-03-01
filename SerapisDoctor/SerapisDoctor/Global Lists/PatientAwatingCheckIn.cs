using SerapisDoctor.Model.Patient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Collections.Specialized;
using System.Linq;

namespace SerapisDoctor.Global_Lists
{
    public static class PatientAwatingCheckIn
    {
        public static ObservableCollection<Patient> PatientsBooked = new ObservableCollection<Patient>();

        public static ObservableCollection<Patient> GetPatients()
        {
            return PatientsBooked;
        }

        public static void AddPatient(Patient patient)
        {
            PatientsBooked.Add(patient);
            UpdateList();
        }

       public static ObservableCollection<Patient> UpdateList()
       {
            Sort();
            return PatientsBooked;
       }

        public static void Sort()
        {
            //sort list
           
        }

        public static void RemoveFromList(Patient patient)
        {
            var indexOfPatient=PatientsBooked.IndexOf(patient);
            PatientsBooked.Remove(patient);
            UpdateList();
            
        }

        public static void ClearList()
        {
            PatientsBooked.Clear();
        }

    }
}
