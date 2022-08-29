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
        IDictionary<int, string> GetReciepes();
        IProduct GetIngredientsForProduct(int productId);

        bool AddComponent();

        bool AddProduct(string query, IEnumerable<SqlParameter> sqlParameter, out int newId);
        bool SaveReciepeToDataBase(int newId, string productName, string massUnit, decimal productContent, int totalUnitId, string readyMass);


    }
}
