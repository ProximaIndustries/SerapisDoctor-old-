using SerapisDoctor.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Collections.Specialized;
using System.Linq;
using SerapisDoctor.Services;
using SerapisDoctor.Model.PatientModel;

namespace SerapisDoctor.Global_Lists
{
    public static class PatientAwatingCheckIn
    {
        public static ObservableCollection<PatientMeta> PatientsBooked = new ObservableCollection<PatientMeta>();

        public static ObservableCollection<PatientMeta> GetPatients()
        {
            foreach (var patient in DataStore.GetBookedPatients())
            {
                PatientsBooked.Add(patient);
            }

            return PatientsBooked;
        }

        public static void AddPatient(PatientMeta patient)
        {
            PatientsBooked.Add(patient);
            UpdateList();
        }

       public static ObservableCollection<PatientMeta> UpdateList()
       {
            Sort();
            return PatientsBooked;
       }

        public static void Sort()
        {
            //sort list
           
        }

        public static void RemoveFromList(PatientMeta patient)
        {
            var indexOfPatient=PatientsBooked.IndexOf(patient);

            try
            {
                var element = PatientsBooked.Where(x => x.FullName == patient.FullName);

                PatientsBooked.Remove(element.FirstOrDefault());
            }
            catch(TimeoutException timeout)
            {
                throw timeout.InnerException;
            }

            UpdateList();
        }

        public static void ClearList()
        {
            PatientsBooked.Clear();
        }

    }
}
