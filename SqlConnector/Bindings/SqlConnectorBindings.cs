using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnector.Bindings
{
    public class SqlConnectorBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ISqlConnector>().To<MSSqlConnector>();
        }
    }
}
