using NutritionCreatorFramework.DbConnection.Interfaces;
using NutritionCreatorFramework.Units;
using NutritionCreatorFramework.UserLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.DbConnection.MSSql
{
    internal class MSSqlRepository : ISqlRepository
    {
        private readonly string ConnectionString;

        private readonly IUserLogger _logger;
        public MSSqlRepository(ILoggerFactory logger)
        {
            _logger = logger.Create("file");
            if (File.Exists(StaticNames.connectionToSql))
            {
                using (var sr = new StreamReader(StaticNames.connectionToSql))
                {
                    ConnectionString = sr.ReadToEnd();
                }
            }
        }
        public IEnumerable<IUnit> GetUnits()
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            var result = new List<IUnit>();
            using (var cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT Jednostka_Id, Jednostka_Nazwa, Jednostka_Mnoznik FROM Jednostki ORDER BY Jednostka_Mnoznik";
                using (var reader = cmd.ExecuteReader())
                {
                    

                    while (reader.Read())
                    {
                        var id = reader["Jednostka_Id"].ToString();
                        var name = reader["Jednostka_Nazwa"].ToString();
                        var counter = reader["Jednostka_Mnoznik"].ToString();

                        var unit = new Unit(id, name, counter);
                        result.Add(unit);     
                    }
                }

            }
            return result;
        }

        public bool AddComponent()
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            using (var cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO ";
                cmd.ExecuteNonQuery();

            }

            return false;
        }

        public bool AddProduct(string query, SqlParameter sqlParameter)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            using (var cmd = sqlConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandText = query;
                    cmd.Parameters.Add(sqlParameter);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e )
                {
                    _logger.Log($"Error while product adding {e.Message}");
                    return false;
                }
            }

        }
    }
}
