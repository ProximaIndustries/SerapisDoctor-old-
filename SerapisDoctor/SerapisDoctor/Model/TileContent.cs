using System;
using System.Collections.Generic;
using System.Text;
using SerapisDoctor.Model.AppointmentModel;
using SerapisDoctor.Model.Doctor;

namespace SerapisDoctor.Model
{
    public class TileContent
    {
        public MedicationContent MContent { get; set; }

        public CheckInContent ChkContent { get; set; }

        public NoteAndFileContent NContent { get; set; }
    }

     public class MedicationContent
    {
        public string MedicationImage { get; set; }

        public string MedicationName { get; set; }
    }

    public class CheckInContent
    {
      
        public Appointment AppointmentSummary { get; set; }

        public SerapisDoctor.Model.Doctor.Doctor DoctorName { get; set; }

        public string Place { get; set; }

    }

    public class NoteAndFileContent
    {
        public string NoteIcon { get; set; }

        public DoctorsNote NoteContent { get; set; }
    }
}
