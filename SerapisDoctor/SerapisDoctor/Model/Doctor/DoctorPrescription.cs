using SerapisDoctor.Model.Enum;

namespace SerapisDoctor.Model.Doctor
{
    public class DoctorPrescription
    {
        public int Id { get; set; }
        public string PrescriptionDosage { get; set; }
        public string PrescriptionInstructions { get; set; }
        public string PrescriptionMedication { get; set; }
        public string AddedPrescriptionNotes { get; set; }
        public double MedCashPrice { get; set; }
        public MedicationType TypeOfMedication { get; set; }
    }
}
