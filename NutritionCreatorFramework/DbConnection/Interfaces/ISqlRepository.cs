using NutritionCreatorFramework.Units;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.DbConnection.Interfaces
{
    public interface ISqlRepository
    {
        IEnumerable<IUnit> GetUnits();
        bool AddComponent();

        bool AddProduct(string query, SqlParameter sqlParameter);
    }
}
