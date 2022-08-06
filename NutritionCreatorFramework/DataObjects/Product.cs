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

        public IEnumerable<IIngredient> Ingredients {get;}

        public decimal Quantity {get;}

        public Product(string name, IEnumerable<IIngredient> ingredients, decimal quantity)
        {
            Name = name;
            Ingredients = ingredients;
            Quantity = quantity;
        }

        public IEnumerable<IIngredient> GetIngredients()
        {
            var newIngredients = new List<IIngredient>();
            foreach (var item in Ingredients)
            {
                var ingredient = new Ingredient(item.Name, item.Id, item.Quantity * Quantity, item.Unit);
                newIngredients.Add(ingredient);
            }
            return newIngredients;
        }
    }
}
