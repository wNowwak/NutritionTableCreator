using NutritionCreatorFramework.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.DataObjects
{
    public class Ingredient : IIngredient
    {
        public string Name {get;}

        public int Id {get;}

        public decimal Quantity {get;}

        public IUnit Unit {get;}


        public Ingredient(string name, int id, decimal quantity, IUnit unit)
        {
            Name = name;
            Id = id;
            Quantity = quantity;
            Unit = unit;
        }
    }
}
