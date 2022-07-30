using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnector
{
    public class SqlConnectionData : ISqlConnectionData
    {
        public string ServerName {get ;}

        public string DatabaseName {get ;}

        public string User {get ;}

        public string Password {get ;}

        public bool WinAuth {get ;}

        public SqlConnectionData(string serverName, string databaseName, string user, string password, bool winAuth)
        {
            ServerName = serverName;
            DatabaseName = databaseName;
            User = user;
            Password = password;
            WinAuth = winAuth;
        }
    }
}
