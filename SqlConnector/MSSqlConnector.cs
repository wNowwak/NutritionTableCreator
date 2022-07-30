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
            };

            try
            {
                using (var connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
                {
                    connection.Open();
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
    }
}
