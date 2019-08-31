using SerapisDoctor.Model.Enum;
using System.Collections.Generic;

namespace SerapisDoctor.ViewModel.PopUpViewModel
{
    public class MedicationTypePopUpVM
    {
        public List<MedicationType> MedicationTypeList { get; set; }

        public MedicationTypePopUpVM()
        {
            InitalizeList();
        }

        private List<MedicationType> InitalizeList()
        {
            MedicationTypeList = new List<MedicationType>()
            {
                MedicationType.bandage,
                MedicationType.capsule,
                MedicationType.ointment,
                MedicationType.pills,
                MedicationType.syringe
            };

            return MedicationTypeList;
        }

    }

}
