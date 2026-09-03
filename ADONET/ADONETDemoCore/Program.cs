using EFCoreDemo.Models;
using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;

namespace ADONETDemoCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\serhi\source\repos\sabatex-ITStep\ADONETLesson\WpfAppADONETDemo\restoran.mdf;Integrated Security=True"))
            {
                dbConnection.Open();
                var dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = "select * from Waiters";
                var dbReader = dbCommand.ExecuteReader();
                while (dbReader.Read())
                {
                    Console.WriteLine($"{dbReader.GetInt32(0)}  {dbReader.GetString(1)}");
                }
                dbReader.Close();

                var str = File.ReadAllText(@"C:\DataBases\DemoData.json");
                var demoData = System.Text.Json.JsonSerializer.Deserialize<PeopleDemoData[]>(str);
                var rnd = new Random();

                var tr = dbConnection.BeginTransaction();

                dbCommand = dbConnection.CreateCommand();
                dbCommand.Transaction = tr;
                dbCommand.CommandText = "insert into Waiters (name) values (@name)";
                var paramName = dbCommand.CreateParameter();
                paramName.ParameterName = "name";
                int index = rnd.Next(1, 10000);
                var r = demoData.Single(s => s.id == index);
                paramName.Value = $"{r.firstname} {r.lastname}";
                dbCommand.Parameters.Add(paramName);

                dbCommand.ExecuteNonQuery();

                tr.Commit();

                dbConnection.Close();
            }
            

        }
    }
}
