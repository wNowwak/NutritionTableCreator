using Ninject.Modules;
using NutritionCreatorFramework.UserLogger.Factories;
using NutritionCreatorFramework.UserLogger.Interfaces;

namespace NutritionCreatorFramework.UserLogger.Bindings
{
    public class UserLoggerBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoggerFactory>().To<LoggerFactory>();

        }
    }
}
