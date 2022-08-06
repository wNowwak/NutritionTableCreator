using NutritionCreatorFramework.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.DataObjects
{
    public interface IIngredient
    {
        string Name { get; }
        int Id { get; }
        decimal Quantity { get; }
        IUnit Unit { get; }
    }
}
