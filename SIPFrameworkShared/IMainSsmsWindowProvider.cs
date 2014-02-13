using System;
using System.Collections.Generic;

namespace RedGate.SIPFrameworkShared
{
    public interface IMainSsmsWindowProvider
    {
        IWindow ObjectExplorer { get; }
        IWindow GetWindowFromGuid(Guid guid);
    }

    public enum SaveChanges
    {
        Yes,
        No,
        Prompt,
    }

    public enum WindowState
    {
        Normal,
        Minimize,
        Maximize,
    }

    public interface IWindow
    {
        void SetFocus();
        void Detach();
        void Attach(int lWindowHandle);
        void Activate();
        void Close(SaveChanges saveChanges = SaveChanges.No);
        bool Visible { get; set; }
        int Left { get; set; }
        int Top { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        WindowState WindowState { get; set; }
        IEnumerable<IWindow> LinkedWindows { get; }
        int HWnd { get; }
        string Kind { get; }
        string ObjectKind { get; }
        object Object { get; }
        bool Linkable { get; set; }
        string Caption { get; set; }
        bool IsFloating { get; set; }
        bool AutoHides { get; set; }
        object LinkedWindowFrame { get; }
        string LinkedWindowFrameCaption { get; }
        void Dock();
        void UnDock();
    }
}