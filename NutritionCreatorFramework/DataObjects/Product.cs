using NutritionCreatorFramework.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.DataObjects
{
    public class Product : IProduct
    {
        public string Name {get;}

        public IList<IIngredient> Ingredients {get;}

        public decimal Quantity {get;}
        public IUnit  Unit {get;}

        public Product(string name, IList<IIngredient> ingredients, decimal quantity, IUnit unit)
        {
            Name = name;
            Ingredients = ingredients;
            Quantity = quantity;
            Unit = unit;
        }

        public IEnumerable<IIngredient> GetIngredients()
        {
            var newIngredients = new List<IIngredient>();
            foreach (var item in Ingredients)
            {
                var ingredient = new Ingredient(item.Name, item.Id, item.Quantity , item.Unit);
                newIngredients.Add(ingredient);
            }
            return newIngredients;
        }
    }
}
