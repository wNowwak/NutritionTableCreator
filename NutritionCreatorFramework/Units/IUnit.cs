using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.Units
{
    public interface IUnit
    {
        int Id { get; }
        string Name { get; }
        int Counter { get; }
        bool IsLiquid { get; }

        string ToString();
    }
}
