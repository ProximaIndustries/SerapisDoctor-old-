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

        public static Task<List<PateintMeta>> GetPatientsAsync()
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

        

        public static void InsertPatient(PateintMeta patientMetaData)
        {
            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                conn.CreateTable<PateintMeta>();
                conn.Insert(patientMetaData);
            }
        }

        //Used for editing a patient object in the local database
        public async static Task SaveItemAsync(PateintMeta patientLocal)
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

                        conn.Update(p);
                    }
                    else
                    {
                        //insert the patient in the local database
                        conn.Insert(patientLocal);
                    }
                }
            }
        }

        public static Task DeletePatientAsync(PateintMeta localId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                conn.CreateTable<PateintMeta>();
                var patient = conn.Table<PateintMeta>().Where(i => i.LocalId == localId.LocalId).FirstOrDefault();

                return Task.FromResult(conn.Delete<PateintMeta>(patient));
            }
        }
    }
}
