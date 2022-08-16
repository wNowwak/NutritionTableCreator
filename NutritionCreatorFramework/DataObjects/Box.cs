using NutritionCreatorFramework.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.DataObjects
{
    public class Box : IBox
    {
        public IUnit Unit { get; }

        public decimal Size { get; }

        public Box(IUnit unit, decimal size)
        {
            Unit = unit;
            Size = size;
        }
    }
}
