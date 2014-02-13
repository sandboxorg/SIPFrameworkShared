using System;
using System.Windows.Forms;

namespace RedGate.SIPFrameworkShared
{
    public interface IToolWindowService
    {
        IToolWindow Create(Control control, string caption, Guid guid, bool isMdiTab = true);
        IToolWindow Create(object wpfControl, string caption, Guid guid, bool isMdiTab = true);
    }

    public interface IToolWindow
    {
        object Control { get; }
        bool HasSavedPosition { get; }
        int Height { get; set; }
        int Width { get; set; }
        int Top { get; set; }
        int Left { get; set; }
        void Activate(bool getFocus);
        void Deactivate();
        bool IsVisible { get; }
        IWindow Window { get; }
    }
}