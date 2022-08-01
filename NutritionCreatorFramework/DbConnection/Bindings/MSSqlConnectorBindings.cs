using Ninject.Modules;
using NutritionCreatorFramework.DbConnection.Interfaces;
using NutritionCreatorFramework.DbConnection.MSSql;

namespace NutritionCreatorFramework.DbConnection.Bindings
{
    public class MSSqlConnectorBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ISqlConnector>().To<MSSqlConnector>();
        }
    }
}
