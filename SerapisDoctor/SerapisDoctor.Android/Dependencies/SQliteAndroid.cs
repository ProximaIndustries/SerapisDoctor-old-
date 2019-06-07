using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SerapisDoctor.Droid.Dependencies
{
    public class SQliteAndroid
    {
        public SQLiteConnection GetConnection()
        {
            string fileName = "patients_db.db3";

            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            //Combines the name and the path
            string completePath = Path.Combine(folderPath, fileName);

            
            var path = Path.Combine(folderPath, fileName);
            var connection = new SQLiteConnection(path);
            return connection;

        }
    }
}