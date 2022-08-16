using NutritionCreatorFramework.DataObjects;
using NutritionCreatorFramework.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.LabelToPngGenerator.Interfaces
{
    public interface ILabelGenerator
    {
        void GenerateLabel(string path, IList<IIngredient> ingredients, IBox box, IBox totalProduct, decimal portionCount, IEnumerable<IUnit> units);
    }
}
