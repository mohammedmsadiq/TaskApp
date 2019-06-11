using System;
using System.IO;
using SQLite;
using TaskApp.Interface;
using Xamarin.Forms;

namespace TaskApp.Droid.Implementations
{
[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLite))]  
namespace SQLiteSample.Droid.Implementations
    {
        public class AndroidSQLite : ISQLiteInterface
        {
            public SQLiteConnection GetConnection()
            {
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                // Documents folder  
                var path = Path.Combine(documentsPath, DatabaseHelper.DbFileName);
                var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                var conn = new SQLiteConnection(plat, path);

                // Return the database connection  
                return conn;
            }
        }
    }

