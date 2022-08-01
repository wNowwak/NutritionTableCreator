using NutritionCreatorFramework.DbConnection.Interfaces;
using NutritionCreatorFramework.DbConnection.MSSql;
using NutritionCreatorFramework.UserLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutritionCreatorFramework
{
    public partial class DataBaseConnector : Form
    {
        private const string connectionSqlPath = "connectionToSql";
        private readonly IUserLogger _logger;
        private readonly ISqlConnector _connector;
        public DataBaseConnector(IUserLogger logger, ISqlConnector connector)
        {
            InitializeComponent();
            _logger = logger;
            _connector = connector;

            TryLoadConnectionData();
        }
        private void TryLoadConnectionData()
        {
            string dataSourcePrefix = "Data Source=";
            string initialCatalogPrefix = "Initial Catalog=";
            string userIdPrefix = "User ID=";
            string passwordPrefix = "Password=";

            if (File.Exists(connectionSqlPath))
            {
                using (var sr = new StreamReader(connectionSqlPath))
                {

                    var connectionData = sr.ReadToEnd().Split(';');

                    var dataSource = connectionData.Where(x => x.StartsWith(dataSourcePrefix)).FirstOrDefault() ?? string.Empty;
                    var initialCatalog = connectionData.Where(x => x.StartsWith(initialCatalogPrefix)).FirstOrDefault() ?? string.Empty;
                    var userId = connectionData.Where(x => x.StartsWith(userIdPrefix)).FirstOrDefault() ?? string.Empty;
                    var password = connectionData.Where(x => x.StartsWith(passwordPrefix)).FirstOrDefault() ?? string.Empty;

                    txtServer.Text = dataSource.Replace(dataSourcePrefix, "");
                    txtDataBase.Text = initialCatalog.Replace(initialCatalogPrefix, "");
                    txtUser.Text = userId.Replace(userIdPrefix, "");
                    txtPassword.Text = password.Replace(passwordPrefix, "").Trim();

                }
                this.Refresh();
            }
        }

        private void btnConnectToDb_Click(object sender, EventArgs e)
        {
            try
            {
                string server = txtServer?.Text ?? string.Empty;
                string password = txtPassword?.Text ?? string.Empty;
                string user = txtUser?.Text ?? string.Empty;
                string database = txtDataBase?.Text ?? string.Empty;
                bool isWinAuthentication = isWinAuth.Checked;
                ISqlConnectionData sqlConnectionData = new MSSqlConnectionData(
                    server, database, user, password, isWinAuthentication);
                var breakLoop = _connector.ConnectToSql(sqlConnectionData, out var message);
                lblError.Text = message;
                if (breakLoop)
                {
                    lblError.ForeColor = Color.Green;
                }
                else
                {
                    lblError.ForeColor = Color.Red;
                }
                this.Refresh();



            }
            catch (Exception ex)
            {
                _logger.Log($"{ex.Message}");
                _logger.Log($"{ex.StackTrace}");
                throw;
            }

        }
    }
}
