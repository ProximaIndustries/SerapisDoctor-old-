using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SerapisDoctor.Global_Lists
{
    public static class PriscriptionScriptList
    {
        public static ObservableCollection<Model.Doctor.DoctorPrescription> prescription { get; set; }

        public static void AddMedicationToBusket(Model.Doctor.DoctorPrescription meds)
        {
             prescription.Add(meds);
        }


        public static ObservableCollection<Model.Doctor.DoctorPrescription> GetList()
        {
            return prescription;
        }

        public static void RemoveMeds(Model.Doctor.DoctorPrescription med) 
        {
            prescription.Remove(med);
        }

        public static int CountBusketItemsNum()
        {
            int numberOfItems=prescription.Count;
            return numberOfItems;
        }

        public static double TotalRandAmount()
        {
            double TotalAmount=0;
            foreach (var item in prescription)
            {
                TotalAmount=+item.MedCashPrice;
            }

            return TotalAmount;
        }
    }
}
