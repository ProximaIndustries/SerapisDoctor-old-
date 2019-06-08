using SerapisDoctor.Model.Patient;
using SQLitePCL;
using System;
using System.Collections.Generic;
using SQLite;
using System.Text;
using System.Threading.Tasks;
using SerapisDoctor.Services.Interfaces;
using Xamarin.Forms;

namespace SerapisDoctor.Services
{
    public static class PatientsWaintingLineDb
    {
        readonly static string database=App.Database;
        public static SQLiteConnection conn;

        //Get all patients in the Sqlite database
        public static Task<List<PateintMeta>> GetPatientsAsync()
        {
            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                conn.CreateTable<PateintMeta>();
                var patients = conn.Table<PateintMeta>().ToList();

                return Task.FromResult(patients);
            }
        }

        //Get all the patients saved in the SQLIte database
        public static Task<PateintMeta> GetItemAsync(PateintMeta patientLocalDbId)
        {
            int id = patientLocalDbId.LocalId;

            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                conn.CreateTable<PateintMeta>();
                var patient = conn.Table<PateintMeta>().Where(i => i.LocalId == id).FirstOrDefault();

                return Task.FromResult(patient);
            }
        }
  
        //Add the pateint to the local database
        public static void InsertPatient(PateintMeta patientMetaData)
        {
            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                conn.CreateTable<PateintMeta>();
                conn.Insert(patientMetaData);
            }
        }

        //Used for editing a patient object in the local database
        public static Task SaveItemAsync(PateintMeta patientLocal)
        {
            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                //1)Check if the item present 
                  conn.CreateTable<PateintMeta>();

                foreach (var patient in conn.Table<PateintMeta>().ToList())
                {
                    if (patient.LocalId == patientLocal.LocalId)
                    {
                        //edit the patient and save
                        var p=conn.Table<PateintMeta>().FirstOrDefault();

                         p = new PateintMeta
                        {
                              LineNumber=patientLocal.LineNumber
                        };

                       return Task.FromResult(conn.Update(p));
                    }
                    else
                    {
                        //insert the patient in the local database
                        return Task.FromResult(conn.Insert(patientLocal));
                    }
                }

                return null;
            }
        }

        //Remove a patient from the local SQlite database 
        public static Task DeletePatientAsync(PateintMeta localId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                conn.CreateTable<PateintMeta>();
                var patient = conn.Table<PateintMeta>().Where(i => i.LocalId == localId.LocalId).FirstOrDefault();

                return Task.FromResult(conn.Delete<PateintMeta>(patient));
            }
        }


        //Clears all pateints from the local Database, I mean all of them.
        public static Task ClearLocalDatabaseAsync()
        {
            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                conn.CreateTable<PateintMeta>();
                return Task.FromResult(conn.DeleteAll<PateintMeta>());
            }
        }
    }
}
