namespace NutritionCreatorFramework.UserLogger.Interfaces
{
    public interface ILoggerFactory
    {
        IUserLogger Create(string type);
    }
}
