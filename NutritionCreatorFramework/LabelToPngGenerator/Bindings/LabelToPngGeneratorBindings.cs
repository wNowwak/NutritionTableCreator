using Ninject.Modules;
using NutritionCreatorFramework.LabelToPngGenerator.Generator;
using NutritionCreatorFramework.LabelToPngGenerator.Interfaces;

namespace NutritionCreatorFramework.LabelToPngGenerator.Bindings
{
    public class LabelToPngGeneratorBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILabelGenerator>().To<LabelGenerator>();
        }
    }
}
