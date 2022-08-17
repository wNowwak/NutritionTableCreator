using NutritionCreatorFramework.DataObjects;
using NutritionCreatorFramework.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NutritionCreatorFramework.HtmlFactory
{
    internal class HtmlRow
    {
        public IList<HtmlCell> cells { get; set; }
        
        public HtmlRow(IIngredient ingredient, bool addName)
        {
            cells = new List<HtmlCell>();
            if(addName)
                cells.Add(new HtmlCell(ingredient.Name));
            cells.Add(new HtmlCell($"{Math.Round(ingredient.Quantity,2)} {ingredient.Unit.ToString()}"));
        }

        public string GetRow()
        {
            var result = string.Empty;
            foreach (var item in cells)
            {
                result += item.ToHtml();
            }
            
            return result;
        }
    }
}
