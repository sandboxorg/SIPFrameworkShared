using System;
using System.Windows.Forms;

namespace RedGate.SIPFrameworkShared.Connections
{
    public class ConnectionDialogOpenedEventArgs : EventArgs
    {
        private readonly Control m_Control;

        public ConnectionDialogOpenedEventArgs(Control control)
        {
            m_Control = control;
        }

        public Control Control
        {
            get { return m_Control; }
        }
    }
}