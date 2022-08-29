using NutritionCreatorFramework.DataObjects;
using NutritionCreatorFramework.HtmlFactory;
using NutritionCreatorFramework.LabelToPngGenerator.Interfaces;
using NutritionCreatorFramework.Units;
using NutritionCreatorFramework.UserLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace NutritionCreatorFramework.LabelToPngGenerator.Generator
{
    public class LabelGenerator : ILabelGenerator
    {
        private readonly HtmlGenerator _htmlGenerator;
        private readonly IUserLogger _logger;
        public LabelGenerator(HtmlGenerator htmlGenerator, ILoggerFactory factory)
        {
            _htmlGenerator = htmlGenerator;
            _logger = factory.Create("file");
        }

        public void GenerateLabel(string path, IList<IIngredient> ingredients, IBox box, IBox totalProduct, decimal portionCount, IEnumerable<IUnit> units, string labelName)
        {
            var countOfBoxes = CountBoxes(box, totalProduct);
            var htmlContent = string.Empty;
            using (var reader = new StreamReader(path+@"\label.html"))
            {
                htmlContent = reader.ReadToEnd().Trim();
            }
            var content = CreateContent(CreatePortion(ingredients, portionCount, countOfBoxes, units), CreateBox(ingredients, countOfBoxes, units), box);
            
            htmlContent = htmlContent.Replace("**ROWS**", content);
            _logger.Log(htmlContent);

            Image image = HtmlRender.RenderToImage(htmlContent);
            image.Save($"{path}{labelName}", ImageFormat.Png);

        }


        private string CreateContent(IList<IIngredient> ingredientsPortion, IList<IIngredient> ingredientsBox, IBox box)
        {
            return _htmlGenerator.GetHtml(ingredientsPortion, ingredientsBox,box);
        }
        private IList<IIngredient> CreatePortion(IList<IIngredient> ingredients, decimal countOfPortion, decimal countOfBoxes, IEnumerable<IUnit> units)
        {
            var result = new List<IIngredient>();  
            foreach (var ingredient in ingredients)
            {
                var ing = new Ingredient(ingredient.Name, ingredient.Id, ConvertToNewUnit((ingredient.Quantity * ingredient.Unit.CounterValue) / (countOfPortion * countOfBoxes), out var newUnit, units), newUnit);
                result.Add(ing);
            }
            return result;
        }
        private IList<IIngredient> CreateBox(IList<IIngredient> ingredients, decimal countOfBoxes, IEnumerable<IUnit> units)
        {
            var result = new List<IIngredient>();
            foreach (var ingredient in ingredients)
            {
                var ing = new Ingredient(ingredient.Name, ingredient.Id, ConvertToNewUnit((ingredient.Quantity * ingredient.Unit.CounterValue) / (countOfBoxes), out var newUnit, units), newUnit);
                result.Add(ing);
            }
            return result;
        }
        private decimal CountBoxes(IBox box, IBox totalBox)
        {
            var result = (totalBox.Size * (decimal)(Math.Pow(10, (double)totalBox.Unit.Counter))) / (box.Size * (decimal)(Math.Pow(10, (double)box.Unit.Counter)));
            return result;
        }

        private decimal ConvertToNewUnit(decimal quantity, out IUnit unit, IEnumerable<IUnit> units)
        {
            unit = null;
            decimal counter;
            if (quantity >= Convert.ToDecimal(Math.Pow(10, 3)))
            {
                counter = 1000;
                quantity = quantity / counter;

                unit = GetUnit(units,3);
                return quantity;
            }
            else if (quantity < Convert.ToDecimal(Math.Pow(10, 3)) && quantity >= Convert.ToDecimal(Math.Pow(10, 0)))
            {
                unit = GetUnit(units, 0);
                return quantity;
            }
            else if (quantity < Convert.ToDecimal(Math.Pow(10, 0)) && quantity >= Convert.ToDecimal(Math.Pow(10, -3)))
            {
                counter = Convert.ToDecimal(Math.Pow(10, -3));
                quantity = quantity / counter;
                unit = GetUnit(units, -3);
                return quantity;
            }
            else
            {
                counter = Convert.ToDecimal(Math.Pow(10, -6));
                quantity = quantity / counter;
                unit = GetUnit(units, -6);
                return quantity;
            }



        }
        private IUnit GetUnit(IEnumerable<IUnit> units, int counter)
        {
            return units.Where(x => x.Counter == counter && !x.IsLiquid).FirstOrDefault();
        }
        private IUnit GetUnit(IEnumerable<IUnit> units, string name)
        {
            return units.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}