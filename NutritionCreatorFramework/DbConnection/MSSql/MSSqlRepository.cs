using NutritionCreatorFramework.DataObjects;
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

        public bool AddProduct(string query, IEnumerable<SqlParameter> sqlParameter, out int newId)
        {
            newId = 0;
            var sqlConnection = new SqlConnection(ConnectionString);
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            using (var cmd = sqlConnection.CreateCommand())
            {
                try
                {
                    
                    cmd.CommandText = query.Trim();
                    foreach (var parameter in sqlParameter)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    cmd.Prepare();
                    var result = cmd.ExecuteScalar();
                    int.TryParse(result?.ToString(), out newId);
                    return true;
                }
                catch (SqlException sqlEx)
                {
                    newId = sqlEx.ErrorCode;
                    _logger.Log($"Error while product adding {sqlEx.Message}");
                    return false;
                }
                catch (Exception e )
                {
                    _logger.Log($"Error while product adding {e.Message}");
                    return false;
                }
            }

        }

        public IEnumerable<string> GetComponents()
        {
            var query = @"SELECT  * FROM Skladniki";

            var sqlConnection = new SqlConnection(ConnectionString);
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            var result = new List<string>();
            using (var cmd = sqlConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandText = query;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader["Skaldnik_Nazwa"].ToString());
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.Log($"Error while product adding {e.Message}");
                    return null;
                }
            }
            return result;

        }

        public IEnumerable<IProduct> GetProducts()
        {
            var query = Queries.GetProducts;
            var sqlConnection = new SqlConnection(ConnectionString);
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            var result = new List<IProduct>();
            using (var cmd = sqlConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandText = query;
                    using (var reader = cmd.ExecuteReader())
                    {
                        int lastId = 0;
                        IProduct product = null;
                        while (reader.Read())
                        {
                            var productId = StringExtensionMethod.GetIntFromString(reader["PRID"].ToString());
                            if(productId != lastId)
                            {
                                var productName = reader["NAZWA"].ToString();
                                var quantity = StringExtensionMethod.GetDecimalFromString(reader["QTY"].ToString());
                                
                                var unit = new Unit(reader["JMID"].ToString(), reader["JMNAME"].ToString(), reader["JMMN"].ToString());
                                product = new Product(productName,new List<IIngredient>(), quantity, unit);
                                result.Add(product);
                                lastId = productId;
                            }
                            string name = reader["SKL_NAZWA"].ToString();
                            int id = StringExtensionMethod.GetIntFromString(reader["SKLID"].ToString());
                            decimal ingredientQuantity = StringExtensionMethod.GetDecimalFromString(reader["ILOSC"].ToString());
                            IUnit ingredientUnit = new Unit(reader["JID"].ToString(), reader["JNAME"].ToString(), reader["JMN"].ToString());
                            var ingerdient = new Ingredient(name, id, ingredientQuantity, ingredientUnit);
                            result.Last().Ingredients.Add(ingerdient);
                            
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.Log($"Error while product adding {e.Message}");
                    return null;
                }
            }
            return result;
        }
    }
}
