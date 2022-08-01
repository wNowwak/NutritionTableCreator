namespace NutritionCreatorFramework.DbConnection.Interfaces
{
    public interface ISqlConnectionData
    {
        string ServerName { get; }
        string DatabaseName { get; }
        string User { get; }
        string Password { get; }
        bool WinAuth { get; }

    }
}
