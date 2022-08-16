using NutritionCreatorFramework.DataObjects;
using NutritionCreatorFramework.Units;
using System;
using System.Collections.Generic;

namespace NutritionCreatorFramework.HtmlFactory
{
    internal class HtmlRow
    {
        public IList<HtmlCell> cells { get; set; }
        
        public HtmlRow(IIngredient ingredient)
        {
            cells = new List<HtmlCell>();
            cells.Add(new HtmlCell(ingredient.Name));
            cells.Add(new HtmlCell($"{Math.Round(ingredient.Quantity,2)} {ingredient.Unit.ToString()}"));
        }

        public string GetRow()
        {
            var result = "<tr>";
            foreach (var item in cells)
            {
                result += item.ToHtml();
            }
            result += "</tr>";
            return result;
        }
    }
}
