using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.Units
{
    internal class Unit : IUnit
    {
        public int Id { get; }
        public string Name { get;}
        public int Counter { get; }
        public Unit(string id, string name, string counter)
        {
            Id = int.Parse(id);
            Name = name;
            Counter = int.Parse(counter);
        }



    }
}
