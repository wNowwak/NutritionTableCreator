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
        IEnumerable<IIngredient>  Ingredients { get; }
        decimal Quantity { get; }

    }
}
