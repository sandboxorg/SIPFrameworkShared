using System;

namespace RedGate.SIPFrameworkShared.Connections
{
    public interface IConnectionManager
    {
        event EventHandler<ConnectionDialogClosedEventArgs> Closed;
        event EventHandler<ConnectionDialogOpenedEventArgs> Opened;
        void ShowConnectionDialog();
        bool TryPromptForServerConnection(out IConnectionInfo connectionInfo);
    }
}