using System;
using System.Windows.Forms;

namespace RedGate.SIPFrameworkShared
{
    public interface ISsmsMainWindow : IWin32Window
    {
        IntPtr Handle { get; }
    }
}