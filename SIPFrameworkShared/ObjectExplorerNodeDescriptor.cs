using System;

namespace RedGate.SIPFrameworkShared
{
    public interface IOe100Node
    {
        string Name { get; }
        string Path { get; }
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