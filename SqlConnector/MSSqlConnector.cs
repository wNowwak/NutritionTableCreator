using ILogger;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnector
{
    public class MSSqlConnector : ISqlConnector
    {
        private readonly IUserLogger _logger;

        public MSSqlConnector(IUserLogger logger)
        {
            _logger = logger;
        }
        public bool ConnectToSql(ISqlConnectionData sqlConnectionData, out string message)
        {
            message = string.Empty;
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = sqlConnectionData.ServerName,
                InitialCatalog = sqlConnectionData.DatabaseName,
                UserID = sqlConnectionData.User,
                Password = sqlConnectionData.Password,
                IntegratedSecurity = false
            };

            try
            {
                using (var connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
                {
                    var connectionString = connection.ConnectionString;
                    connection.Open();
                    connection.Close();
                    message = "Połaczenie ustawione";
                    SaveConnectionString(connectionString);
                    return true;

                }
            }
            catch (Exception ex)
            {
                message = "Nie udało się połaczyć do bazy danych. Sprawdź wprowadzone dane.";
                _logger.Log(ex.Message);
                _logger.Log(ex.StackTrace);
            }
            
            return false;
        }

        private void SaveConnectionString(string connectionString)
        {
            try
            {
                using (var sw = new StreamWriter("connectionToSql"))
                {
                    sw.WriteLine(connectionString);
                }
            }
            catch (Exception ex)
            {
                _logger.Log("Błąd w zapisie connection string "+ex.Message);
                _logger.Log(ex.StackTrace);
            }
        }
    }
}
