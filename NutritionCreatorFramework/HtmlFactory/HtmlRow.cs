using NutritionCreatorFramework.DataObjects;
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
            cells.Add(new HtmlCell(ingredient.Quantity));
        }

        public string GetRow()
        {
            return $"<tr>{String.Join("\n", cells)}</tr>";
        }
    }
}
