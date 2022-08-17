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
        public string GetHtml(IList<IIngredient> ingredients, IList<IIngredient> ingredientsBox, IBox box)
        {
            string html = $"<tr>" +
                $"<th></th>" +
                $"<th>{box.Size}{box.Unit.ToString()}</th>" +
                $"<th>Porcja" +
                $"</tr>";
            
            for(int i = 0; i < ingredients.Count; i++)
            {
                html += "<tr>";
                //html += $"{ingredientsBox[i].Name}";
                html += new HtmlRow(ingredientsBox[i], true).GetRow();
                html += new HtmlRow(ingredients[i], false).GetRow();
                html += "</tr>";
            }
            return html;
        }
    }
}
