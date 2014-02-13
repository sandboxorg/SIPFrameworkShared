using System.Windows.Forms;

namespace RedGate.SIPFrameworkShared
{
    public interface ISsmsInfo
    {
        string Version { get; }
        bool Is2010ShellOrLater { get; }
        Control ObjectExploreTreeControl { get; }
    }
}