using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionCreatorFramework.Units
{
    internal class Unit : IUnit
    {
        public int Id { get; }
        public string Name { get;}
        public int Counter { get; }
        public bool IsLiquid { get; }
        public Unit(string id, string name, string counter, bool isLiquid)
        {
            Id = int.Parse(id);
            Name = name;
            Counter = int.Parse(counter);
            IsLiquid = isLiquid;
         }

        public override string ToString()
        {
            string unicode = string.Empty;
            switch (Name)
            {
                case "kilogram":
                    unicode = "kg";
                    break;
                case "miligram":
                    unicode = "mg";
                    break;
                case "mikrogram":
                    char microSign = '\u00B5';
                    unicode = $"{microSign.ToString()}g";
                    break;
                case "dekagram":
                    unicode = "dag";
                    break;
                case "litr":
                    unicode = "l";
                    break;
                case "mililitr":
                    unicode = "ml";
                    break;
                default:
                    unicode = "g";
                    break;
            }
            return unicode;
        }

    }
}
