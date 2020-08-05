using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace WindowsFormsApp4
{
    class SqliteDataAccess
    {
        public static List<PeopleModel> LoadPeople()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PeopleModel>("SELECT * FROM Person", new DynamicParameters());
                return output.ToList();
            }
        }   
        public static void SavePerson(PeopleModel person)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Person (FirstName, LastName) values (@firstName, @lastName)", person);
            }
        }
        private static string LoadConnectionString(string id="Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
     }
}
