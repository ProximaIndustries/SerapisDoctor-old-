using SerapisDoctor.Model.Doctor;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerapisDoctor.Services
{
    public class PrescriptionLocalDb
    {
        readonly static string database = App.Database;

        public static Task<List<DoctorPrescription>> GetAllDoctorPrescriptionsAsync()
        {
            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                conn.CreateTable<DoctorPrescription>();
                var medications = conn.Table<DoctorPrescription>().ToList();
                return Task.FromResult(medications);
            }
        }

        public static void InsertPrescription(DoctorPrescription prescription)
        {
            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                conn.CreateTable<DoctorPrescription>();
                conn.Insert(prescription);
            }
        }

        public static DoctorPrescription QuerySinglePrescription(DoctorPrescription _prescriptionName)
        {
            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                conn.CreateTable<DoctorPrescription>();
                var prescription = conn.Table<DoctorPrescription>().Where(j => j.PrescriptionMedication == _prescriptionName.PrescriptionMedication).FirstOrDefault();
                return prescription;
            }
        }

        public static void RemovePrescription(DoctorPrescription _prescription)
        {
            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                conn.CreateTable<DoctorPrescription>();
                var prescription = conn.Table<DoctorPrescription>().Where(j => j.PrescriptionMedication == _prescription.PrescriptionMedication).FirstOrDefault();
            }
        }

        public static void ClearBusket()
        {
            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                conn.CreateTable<DoctorPrescription>();
                conn.DeleteAll<DoctorPrescription>();
            }
        }
        
    }
}
