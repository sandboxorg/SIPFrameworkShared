using System.Windows.Forms;

namespace RedGate.SIPFrameworkShared
{
    public interface ISsmsQueryWindowManager
    {
        bool CreateAugmentedQueryWindow(string query, string name, Control control, DatabaseConnectionDescriptor connectionProperties = null);
        string GetActiveAugmentedQueryWindowContents();
        /// <param name="afterCommandName">The qualified name of the command to insert <paramref name="command"/> after, e.g. Edit.Paste</param>
        /// <param name="command">The command to insert.</param>
        void AddQueryWindowContextMenuItem(string afterCommandName, ISharedCommand command);
    }

    public interface IQueryWindowServices
    {
        /// <summary>
        /// Opens a new query window containing the given text.
        /// </summary>
        /// <param name="intialSql">The initial text of the query window.</param>
        void OpenNew(string intialSql);
    }

    public interface IQueryWindowServices2 : IQueryWindowServices
    {
        /// <summary>
        /// Opens a new query window containing the given text.
        /// </summary>
        /// <param name="intialSql">The initial text of the query window.</param>
        /// <param name="scriptName">The name for the query window</param>
        /// <param name="connectionString">The connection string, if you want the query window to be connected</param>
        void OpenNew(string intialSql, string scriptName, string connectionString);
    }
}