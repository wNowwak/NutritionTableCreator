using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelGenerator
{
    public interface ILabelGenerator
    {
        void GenerateLabel(string path);
    }
}
