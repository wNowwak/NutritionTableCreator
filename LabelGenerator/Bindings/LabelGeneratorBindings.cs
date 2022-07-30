using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelGenerator.Bindings
{
    public class LabelGeneratorBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILabelGenerator>().To<Generator>();
        }
    }
}
