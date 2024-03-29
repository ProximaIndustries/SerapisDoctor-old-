﻿using SerapisDoctor.Droid.Dependencies;
using System.Data.SQLite;
using System.IO;
using Xamarin.Forms;
using SerapisDoctor.Services.Interfaces;
using SQLite;
using SQLiteConnection = SQLite.SQLiteConnection;

[assembly: Dependency(typeof(SQliteAndroid))]
namespace SerapisDoctor.Droid.Dependencies
{
    public class SQliteAndroid : ISqlite
    {

        public SQLiteConnection GetConnection()
        {
            string fileName = "patients_db.db3";

            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //Combines the name and the path
            string completePath = Path.Combine(folderPath, fileName);
            var connection = new SQLiteConnection(completePath);
            return connection;
        }
    }
}