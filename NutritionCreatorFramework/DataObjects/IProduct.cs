using NutritionCreatorFramework.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.DataObjects
{
    public interface IProduct
    {
        string Name { get; }
        IList<IIngredient>  Ingredients { get; }
        decimal Quantity { get; }
        IUnit Unit { get; }

    }
}
