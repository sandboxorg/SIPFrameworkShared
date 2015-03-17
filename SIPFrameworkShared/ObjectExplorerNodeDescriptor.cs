using System;

namespace RedGate.SIPFrameworkShared
{
    public interface IOeNode
    {
        string Name { get; }
        string Path { get; }
        string Type { get; }
        bool IsDatabaseObject { get; }
        bool TryGetDatabaseObject(out IDatabaseObjectInfo databaseObjectInfo);
        bool HasConnection { get; }
        bool TryGetConnection (out IConnectionInfo connectionInfo);
        /// <summary>
        /// Required for backwards compatibility with legacy plugins.
        /// </summary>
        /// <returns>The type that legacy plugins used to receive.</returns>
        ObjectExplorerNodeDescriptorBase GetLegacyObjectDescriptor();
    }

    public interface IOeNode2 : IOeNode, IEquatable<IOeNode2>
    {
        bool HasConnection2 { get; }
        bool TryGetConnection2(out IConnectionInfo2 connectionInfo);
        bool HasDatabaseName { get; }
        bool TryGetDatabaseName(out string databaseName);
    }

    public interface IOeNode3 : IOeNode2, IEquatable<IOeNode3>
    {
        /// <summary>
        /// Gets the name of the SQL Server instance as reported by SQL Server.
        /// </summary>
        /// <remarks>
        /// See also https://msdn.microsoft.com/en-us/library/ms187944.aspx.
        /// </remarks>
        string ServerLocalName { get; }
    }

    public interface IConnectionInfo
    {
        string Server { get; }
        bool IsUsingIntegratedSecurity { get; }
        string UserName { get; }
        string Password { get; }
        string ConnectionString { get; }
    }

    public interface IConnectionInfo2 : IConnectionInfo, IEquatable<IConnectionInfo2>
    {
        Version ServerVersion { get; }
        string Database { get; }
    }

    public interface IDatabaseObjectInfo
    {
        string DatabaseName { get; }
        string ObjectName { get; }
        string Schema { get; }
        string Type { get; }
    }

    [Serializable]
    public class DatabaseObjectDescriptor
    {
        public string Schema { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    [Serializable]
    public class DatabaseConnectionDescriptor
    {
        public string ServerName { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ApplicationName { get; set; }
        public Guid ServerType { get; set; }
        public string ConnectionString { get; set; }
    }

    [Serializable]
    public class ObjectExplorerNodeDescriptorBase
    {
        public virtual string TypeDescription
        {
            get
            {
                return string.Format("{0}", GetType());
            }
        }
    }

    [Serializable]
    public class ObjectExplorerNodeDescriptorWithConnection : ObjectExplorerNodeDescriptorBase
    {
        public DatabaseConnectionDescriptor Connection { get; set; }
        public string ParentFolder { get; set; }
        public bool IsSystemNode { get; set; }
        public override string TypeDescription
        {
            get
            {
                if (Connection != null)
                    return string.Format("{0} [{1}]", GetType() ,Connection.ServerType);
                return string.Format("{0} [No Connection]", GetType());
            }
        }
    }

    [Serializable]
    public class ObjectExplorerDatabaseNodeDescriptor : ObjectExplorerNodeDescriptorWithConnection
    {
        public string DatabaseName { get; set; }
    }

    [Serializable]
    public class ObjectExplorerFolderNodeDescriptor : ObjectExplorerDatabaseNodeDescriptor
    {
        public string Folder { get; set; }
        public override string TypeDescription
        {
            get
            {
                return string.Format("{0} [{1}]", GetType(), Folder);
            }
        }
    }

    [Serializable]
    public class ObjectExplorerColumnNodeDescriptor : ObjectExplorerDatabaseNodeDescriptor
    {
        public DatabaseObjectDescriptor DatabaseObject { get; set; }
        public string Column { get; set; }
        public override string TypeDescription
        {
            get
            {
                if (DatabaseObject != null)
                    return string.Format("{0} [{1}]", GetType(), DatabaseObject.Type);
                return string.Format("{0} [No DatabaseObject]", GetType());
            }
        }
    }

    [Serializable]
    public class ObjectExplorerParameterNodeDescriptor : ObjectExplorerDatabaseNodeDescriptor
    {
        public DatabaseObjectDescriptor DatabaseObject { get; set; }
        public string Parameter { get; set; }
        public override string TypeDescription
        {
            get
            {
                if (DatabaseObject != null)
                    return string.Format("{0} [{1}]", GetType(), DatabaseObject.Type);
                return string.Format("{0} [No DatabaseObject]",GetType());
            }
        }
    }

    [Serializable]
    public class ObjectExplorerObjectNodeDescriptor : ObjectExplorerDatabaseNodeDescriptor
    {
        public DatabaseObjectDescriptor DatabaseObject { get; set; }
        public override string TypeDescription
        {
            get
            {
                if (DatabaseObject != null)
                    return string.Format("{0} [{1}]", GetType(), DatabaseObject.Type);
                return string.Format("{0} [No DatabaseObject]", GetType());
            }
        }
    }
}