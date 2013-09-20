using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RedGate.SIPFrameworkShared
{
    public interface ISsmsFunctionalityProvider
    {
        void AddMenuItem(SimpleOeMenuItemBase menuItem);
        void AddTopLevelMenuItem(SimpleOeMenuItemBase menuItem);
    }

    public interface ISsmsExtendedFunctionalityProvider : ISsmsFunctionalityProvider
    {
        /// <param name="type">This must be ComVisible(true)</param>
        ISsmsTabPage CreateTabPage(Type type, string title, string guid);
        Dictionary<DatabaseConnectionDescriptor, List<string>> GetConnectionsAndDatabases();
        void ReportUsage(string message);
        DatabaseConnectionDescriptor GetConnection(IWin32Window parent, String server, String database = null);
        bool ConnectionExists(String server, String database, out DatabaseConnectionDescriptor connectionDescriptor);
    }

    public interface ISsmsFunctionalityProvider3 : ISsmsExtendedFunctionalityProvider
    {
        ISsmsQueryWindowManager GetQueryWindowManager();
        void AddToolbarItem(ISharedCommand command);
        void AddToolsMenuItem(ISharedCommand command);
    }

    public interface ISsmsFunctionalityProvider4 : ISsmsFunctionalityProvider3
    {
        object SsmsDte2 { get; }
        object SsmsAddinInstance { get; }
        IQueryWindowServices QueryWindow { get; }
    }

    public interface IQueryWindowServices
    {
        void OpenNew(string intialSql);
    }
}
