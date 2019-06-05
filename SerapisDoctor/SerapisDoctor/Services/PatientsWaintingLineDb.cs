using SerapisDoctor.Model.Patient;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SerapisDoctor.Services
{
    public class PatientsWaintingLineDb
    {
        readonly SQLiteAsyncConnection database;

        public PatientsWaintingLineDb(string _dbPath)
        {
            database = new SQLiteAsyncConnection(_dbPath);
            database.CreateTableAsync<Patient>().Wait();
        }

        public Task<List<Patient>> GetItemsAsync()
        {
            return database.Table<Patient>().ToListAsync();
        }

        public Task<List<Patient>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Patient>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Patient> GetItemAsync(MongoDB.Bson.ObjectId id)
        {
            return database.Table<Patient>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Patient patient)
        {
            if (patient.Id != null)
            {
                return database.UpdateAsync(patient);
            }
            else
            {
                return database.InsertAsync(patient);
            }
        }

        public Task<int> DeleteItemAsync(Patient patient)
        {
            return database.DeleteAsync(patient);
        }
    }
}
