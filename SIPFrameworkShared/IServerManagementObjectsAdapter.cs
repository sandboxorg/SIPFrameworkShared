using System.Data.SqlClient;

namespace RedGate.SIPFrameworkShared
{
    public interface IServerManagementObjectsAdapter
    {
        string ScriptAsAlter(SqlConnection openSqlConnection, string databaseName, string schemaName, string scriptableObjectName);
    }
}