using SQLitePCL;
using System;
using System.Collections.Generic;
using SQLite;
using System.Text;
using System.Threading.Tasks;
using SerapisDoctor.Services.Interfaces;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using SerapisDoctor.Model.PatientModel;

namespace SerapisDoctor.Services
{
    public static class PatientsWaintingLineDb
    {
        readonly static string database=App.Database;
        public static SQLiteConnection conn;

        //Get all patients in the Sqlite database
        public static Task<List<PatientMeta>> GetPatientsAsync()
        {           
            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                conn.CreateTable<PatientMeta>();
                var patients = conn.Table<PatientMeta>().ToList();

                return Task.FromResult(patients);
            }
        }

        //Get all the patients saved in the SQLIte database
        public static Task<PatientMeta> GetItemAsync(PatientMeta patientLocalDbId)
        {
            int id = patientLocalDbId.LocalId;

            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                conn.CreateTable<PatientMeta>();
                var patient = conn.Table<PatientMeta>().Where(i => i.LocalId == id).FirstOrDefault();

                return Task.FromResult(patient);
            }
        }
  
        //Add the pateint to the local database
        public static void InsertPatient(PatientMeta patientMetaData)
        {
            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                conn.CreateTable<PatientMeta>();
                conn.Insert(patientMetaData);
            }
        }

        //Used for editing a patient object in the local database
        public static Task SaveItemAsync(PatientMeta patientLocal)
        {
            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                //1)Check if the item present 
                  conn.CreateTable<PatientMeta>();

                foreach (var patient in conn.Table<PatientMeta>().ToList())
                {
                    if (patient.LocalId == patientLocal.LocalId)
                    {
                        //edit the patient and save
                        var p=conn.Table<PatientMeta>().FirstOrDefault();

                         p = new PatientMeta
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
        public static Task DeletePatientAsync(PatientMeta localId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                conn.CreateTable<PatientMeta>();
                var patient = conn.Table<PatientMeta>().Where(i => i.LocalId == localId.LocalId).FirstOrDefault();

                return Task.FromResult(conn.Delete<PatientMeta>(patient));
            }
        }


        //Clears all pateints from the local Database, I mean all of them.
        public static void ClearLocalDatabase()
        {
            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                conn.CreateTable<PatientMeta>();
                conn.DeleteAll<PatientMeta>();
            }
        }

        public static void RefreshList()
        {
            using(SQLiteConnection conn=new SQLiteConnection(database))
            {
                
            }
        }
    }
}
