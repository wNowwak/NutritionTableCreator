using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogger.Bindings
{
    public class ILoggerBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoggerFactory>().To<LoggerFactory>();
            Bind<IUserLogger>().To<FileLogger>();
            
        }
    }
}
