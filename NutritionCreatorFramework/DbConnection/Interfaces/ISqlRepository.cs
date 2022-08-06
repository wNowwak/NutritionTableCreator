using NutritionCreatorFramework.DataObjects;
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
        IEnumerable<string> GetComponents();
        IEnumerable<IProduct> GetProducts();

        bool AddComponent();

        bool AddProduct(string query, IEnumerable<SqlParameter> sqlParameter, out int newId);
        
    }
}
