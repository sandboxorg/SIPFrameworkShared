using System.Windows.Forms;

namespace RedGate.SIPFrameworkShared
{
    public interface ISsmsObject
    {
    }

    public interface ISsmsTabPage : ISsmsObject
    {
        void Activate();
        UserControl GetUserControl();
        void Close();
    }
}