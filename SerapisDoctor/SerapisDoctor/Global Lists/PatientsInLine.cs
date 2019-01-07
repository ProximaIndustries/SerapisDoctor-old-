using SerapisDoctor.Model.Patient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SerapisDoctor
{
     public static class PatientsInLine
    {

        public static ObservableCollection<Patient> _list = new ObservableCollection<Patient>();

      
        public static void PatientAdd(Patient patient)
        {
            _list.Add(patient);

            foreach (Patient patientWaiting in _list)
            {
                
            }
        }

        public static ObservableCollection<Patient> UpdateList()
        {
            return _list;
        }

        public static void RemovePatient(Patient patient)
        {
            _list.Remove(patient);
        }

    }
}
