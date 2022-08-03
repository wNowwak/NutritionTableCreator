using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.Units
{
    internal class Unit : IUnit
    {
        public string Name { get;}
        public int Counter { get; }
        public Unit( string name, int counter)
        {
            Name = name;
            Counter = counter;
        }



    }
}
