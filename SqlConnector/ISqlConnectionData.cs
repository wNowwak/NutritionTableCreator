using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnector
{
    public interface ISqlConnectionData
    {
        string ServerName { get; }
        string DatabaseName { get; }
        string User { get; }
        string Password { get; }
        bool WinAuth { get; }

    }
}
