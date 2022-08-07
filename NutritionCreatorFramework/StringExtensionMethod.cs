using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework
{
    public static class StringExtensionMethod
    {
        public static decimal GetDecimalFromString(string number)
        {
            var style = NumberStyles.AllowDecimalPoint;
            decimal result = decimal.TryParse(number.Replace(',','.'),style, CultureInfo.InvariantCulture, out decimal x) ? x : 0; 
            return result;
        }
        public static int GetIntFromString(string number)
        {
            int result = int.TryParse(number, out int x) ? x : 0;
            return result;
        }
    }
}
