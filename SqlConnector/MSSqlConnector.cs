using ILogger;
using System;
using System.Collections.Generic;
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
        public bool ConnectToSql(ISqlConnectionData sqlConnectionData)
        {
            _logger.Log("Test");
            return false;
        }
    }
}
