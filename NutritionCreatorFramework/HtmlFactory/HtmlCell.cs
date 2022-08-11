using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.HtmlFactory
{
    internal class HtmlCell
    {
        private string cellContent { get;}

        public HtmlCell(object cell)
        {
            cellContent = cell.ToString();
        }

        public string ToHtml()
        {
            return $"<td>{cellContent}</td>";
        }

    }
}
