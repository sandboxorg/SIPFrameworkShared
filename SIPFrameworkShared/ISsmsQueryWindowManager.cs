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
}