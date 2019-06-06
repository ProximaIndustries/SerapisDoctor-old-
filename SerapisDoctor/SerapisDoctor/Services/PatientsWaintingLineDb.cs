using SerapisDoctor.Model.Patient;
using SQLitePCL;
using System;
using System.Collections.Generic;
using SQLite;
using System.Text;
using System.Threading.Tasks;

namespace SerapisDoctor.Services
{
    public static class PatientsWaintingLineDb
    {
        readonly static string database=App.Database;

        public static Task<List<PateintMeta>> GetPatientsAsync(PateintMeta metaData)
        {
            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                conn.CreateTable<PateintMeta>();
                var patients = conn.Table<PateintMeta>().ToList();

                return Task.FromResult(patients);
            }
        }

        //public static Task<List<Patient>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<Patient>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}

        public static Task<PateintMeta> GetItemAsync(int id)
        {
            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                conn.CreateTable<PateintMeta>();
                var patient = conn.Table<PateintMeta>().Where(i => i.LocalId == id).FirstOrDefault();

                return Task.FromResult(patient);
            }
        }


        public static void InsertPatient(PateintMeta patientMetaData)
        {
            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                conn.CreateTable<PateintMeta>();
                int rowwsAdded=conn.Insert(patientMetaData);
            }
        }

        public static void SaveItemAsync(Patient patient)
        {
            if (patient.Id != null)
            {
                //Update info
            }
            else
            {
                //Insert into database
            }
        }

        public static Task<PateintMeta> DeleteItemAsync(int localId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                conn.CreateTable<PateintMeta>();
                var patient = conn.Table<PateintMeta>().Where(i => i.LocalId == localId).FirstOrDefault();

                return Task.FromResult(patient);
            }
        }
    }
}
