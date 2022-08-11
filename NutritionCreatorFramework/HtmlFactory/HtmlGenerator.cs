using NutritionCreatorFramework.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.HtmlFactory
{
    public class HtmlGenerator
    {
        public string GetHtml(IList<IIngredient> ingredients)
        {
            string html = string.Empty;
            foreach(var ingredient in ingredients)
            {

                html += new HtmlRow(ingredient).GetRow();
            }
            return html;
        }
    }
}
