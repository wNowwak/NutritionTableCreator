using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.Units
{
    public interface IUnit
    {
        string Name { get; }
        int Counter { get; }
    }
}
