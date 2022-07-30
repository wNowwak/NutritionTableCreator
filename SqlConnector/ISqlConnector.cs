namespace SqlConnector
{
    public interface ISqlConnector
    {
        bool ConnectToSql(ISqlConnectionData sqlConnectionData,out string message);
    }
}
