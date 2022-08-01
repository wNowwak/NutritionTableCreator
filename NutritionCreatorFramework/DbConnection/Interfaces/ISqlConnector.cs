using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.DbConnection.Interfaces
{
    public interface ISqlConnector
    {
        bool ConnectToSql(ISqlConnectionData sqlConnectionData, out string message);
    }
}
