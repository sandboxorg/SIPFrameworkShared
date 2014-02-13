using System;
using System.Windows.Forms;

namespace RedGate.SIPFrameworkShared.Connections
{
    public class ConnectionDialogClosedEventArgs : EventArgs
    {
        private readonly DialogResult m_DialogResult;

        public ConnectionDialogClosedEventArgs(DialogResult dialogResult)
        {
            m_DialogResult = dialogResult;
        }

        public DialogResult DialogResult
        {
            get { return m_DialogResult; }
        }
    }
}