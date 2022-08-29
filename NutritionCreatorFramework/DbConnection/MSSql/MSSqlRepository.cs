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

        public IProduct GetIngredientsForProduct(int productID)
        {
            var query = Queries.getProduct;
            var sqlConnection = new SqlConnection(ConnectionString);
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            
            using (var cmd = sqlConnection.CreateCommand())
            {
                try
                {
                    var sqlParameter = new SqlParameter() { ParameterName = "@PRODUCTID", Value = productID, DbType = DbType.Int32 };
                    cmd.Parameters.Add(sqlParameter);
                    cmd.CommandText = query;
                    cmd.Prepare();
                    using (var reader = cmd.ExecuteReader())
                    {
                        int lastId = 0;
                        IProduct product = null;
                        while (reader.Read())
                        {
                            var productId = StringExtensionMethod.GetIntFromString(reader["PRID"].ToString());
                            if (productId != lastId)
                            {
                                var productName = reader["NAZWA"].ToString();
                                var quantity = StringExtensionMethod.GetDecimalFromString(reader["QTY"].ToString());

                                var unit = new Unit(reader["JMID"].ToString(), reader["JMNAME"].ToString(), reader["JMMN"].ToString(), reader["JMISL"].ToString() == "1");
                                product = new Product(productName, new List<IIngredient>(), quantity * Convert.ToDecimal(Math.Pow(10, unit.Counter)), unit);
                                lastId = productId;
                            }
                            string name = reader["SKL_NAZWA"].ToString();
                            int id = StringExtensionMethod.GetIntFromString(reader["SKLID"].ToString());
                            decimal ingredientQuantity = StringExtensionMethod.GetDecimalFromString(reader["ILOSC"].ToString());
                            IUnit ingredientUnit = new Unit(reader["JID"].ToString(), reader["JNAME"].ToString(), reader["JMN"].ToString(), reader["JISL"].ToString() == "1");
                            var ingerdient = new Ingredient(name, id, ingredientQuantity * Convert.ToDecimal(Math.Pow(10, ingredientUnit.Counter)), ingredientUnit);
                            product.Ingredients.Add(ingerdient);

                        }
                        return product;
                    }
                }
                catch (Exception e)
                {
                    _logger.Log($"Error while product adding {e.Message}");
                    return null;
                }
            }
            

            return null;
        }

        public IDictionary<int, string> GetReciepes()
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            var result = new Dictionary<int, string>();
            using (var cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandText = Queries.GetReciepes;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = StringExtensionMethod.GetIntFromString(reader["Id"].ToString());
                        var name = reader["Name"].ToString();
                        result.Add(id, name);
                    }
                }
            }

                return result;
        }
        public IEnumerable<IUnit> GetUnits()
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            var result = new List<IUnit>();
            using (var cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandText = Queries.GetUnits;
                using (var reader = cmd.ExecuteReader())
                {
                    

                    while (reader.Read())
                    {
                        var id = reader["Jednostka_Id"].ToString();
                        var name = reader["Jednostka_Nazwa"].ToString();
                        var counter = reader["Jednostka_Mnoznik"].ToString();
                        var isLiquid = bool.TryParse(reader["Jednostka_IsLiquid"].ToString(), out bool x) ? x : false;
                        var unit = new Unit(id, name, counter, isLiquid);
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
                                
                                var unit = new Unit(reader["JMID"].ToString(), reader["JMNAME"].ToString(), reader["JMMN"].ToString(), reader["JMISL"].ToString() == "1");
                                product = new Product(productName,new List<IIngredient>(), quantity * Convert.ToDecimal(Math.Pow(10, unit.Counter)), unit);
                                result.Add(product);
                                lastId = productId;
                            }
                            string name = reader["SKL_NAZWA"].ToString();
                            int id = StringExtensionMethod.GetIntFromString(reader["SKLID"].ToString());
                            decimal ingredientQuantity = StringExtensionMethod.GetDecimalFromString(reader["ILOSC"].ToString());
                            IUnit ingredientUnit = new Unit(reader["JID"].ToString(), reader["JNAME"].ToString(), reader["JMN"].ToString(), reader["JISL"].ToString() == "1");
                            var ingerdient = new Ingredient(name, id, ingredientQuantity * Convert.ToDecimal(Math.Pow(10, ingredientUnit.Counter)), ingredientUnit);
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

        public bool SaveReciepeToDataBase(int newId, string productName, string massUnit, decimal productContent, int totalUnitId, string readyMass)
        {
            var parameters = new List<SqlParameter>();
            string query = Queries.AddReciepe;
            var totalMass = StringExtensionMethod.GetDecimalFromString(readyMass ?? String.Empty);
            var units = GetUnits();
            parameters.Add(CreateSqlParameter("@PRODUCT_ID", newId, "int"));
            parameters.Add(CreateSqlParameter("@SKLADNIK_NAZWA", productName, "string", 1024));
            parameters.Add(CreateSqlParameter("@UNIT_ID", units.Where(uni => uni.Name.Equals(massUnit)).FirstOrDefault().Id, "int"));
            parameters.Add(CreateSqlParameter("@COMPONENT_QUANTITY", productContent, "decimal"));
            parameters.Add(CreateSqlParameter("@TOTAL_MASS", totalMass, "decimal"));
            parameters.Add(CreateSqlParameter("@TOTAL_UNIT_ID", totalUnitId, "int"));


            var result = AddProduct(query, parameters, out int x);
            //if (result)
            //{
            //    lblError.Visible = true;
            //    lblError.Text = "Dodano pomyślnie";
            //    lblError.ForeColor = Color.Green;
            //    this.Refresh();
            //}
            return result;
        }

        private SqlParameter CreateSqlParameter(string name, dynamic value, string type, int size = 0)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            if (type == "int")
                parameter.DbType = DbType.Int32;
            else if (type == "string")
            {
                parameter.DbType = DbType.String;
                parameter.Size = size;
            }
            else if (type == "decimal")
            {
                parameter.DbType = DbType.Decimal;
                parameter.Precision = 10;
                parameter.Scale = 4;
            }
            return parameter;
        }

    }
}
