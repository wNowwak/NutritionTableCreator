using NutritionCreatorFramework.DbConnection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.DbConnection.MSSql
{
    public class MSSqlConnectionData : ISqlConnectionData
    {
        public string ServerName { get; }

        public string DatabaseName { get; }

        public string User { get; }

        public string Password { get; }

        public bool WinAuth { get; }

        public MSSqlConnectionData(string serverName, string databaseName, string user, string password, bool winAuth)
        {
            ServerName = serverName;
            DatabaseName = databaseName;
            User = user;
            Password = password;
            WinAuth = winAuth;
        }
    }
}
