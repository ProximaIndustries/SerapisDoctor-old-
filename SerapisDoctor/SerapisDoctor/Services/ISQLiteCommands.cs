using SerapisDoctor.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SerapisDoctor.Services
{
    public interface ISQLiteCommands<T>
    {
        //Gets local Database coonection
        SQLiteConnection GetConnection();

        //Gets all the pateints, currently in the local database
        Task<List<T>> GetPatientsFromLocalDbAsync(PateintMeta metaData);

        //This Id is the id in the PatientMeta model, uses the autoincrment Sqlite property
        Task<PateintMeta> GetPatientFromLocalDbAsync(int id);

        //Insert the pateint to the database
        Task InsertPatientToLocalDbAsync();

        //Delete pateint using the pateint meta model id
        Task DeletePatientFromLocalDbAsync(int id);

        //Update patient in local database,eg. reshceduling then sending to the server
        Task UpdatePatientMetaAsync(int id);
    }
}
