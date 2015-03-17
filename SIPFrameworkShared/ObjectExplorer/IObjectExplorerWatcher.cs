using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace RedGate.SIPFrameworkShared.ObjectExplorer
{
    public delegate void SelectionChangedEventHandler(ISelectionChangedEventArgs args);
    public delegate void SelectionChangedEventHandler2(ISelectionChangedEventArgs2 args);
    public delegate void ConnectionsChangedEventHandler(IConnectionsChangedEventArgs args);

    public interface IConnectionsChangedEventArgs
    {
        IEnumerable<IConnectionInfo2> Connections { get; }
    }

    public interface ISelectionChangedEventArgs
    {
        IOeNode2 Selection { get; }
    }

    public interface ISelectionChangedEventArgs2 : ISelectionChangedEventArgs
    {
        new IOeNode3 Selection { get; }
    }

    public interface IObjectExplorerWatcher
    {
        event SelectionChangedEventHandler SelectionChanged;
        event ConnectionsChangedEventHandler ConnectionsChanged;

        bool TryGetSelectedNode(out IOeNode2 node);
        IEnumerable<IConnectionInfo2> Connections { get; }
        bool TryGetSelectedConnection(out IConnectionInfo2 connection);
    }

    public interface IObjectExplorerWatcher2 : IObjectExplorerWatcher
    {
        bool TryGetSelectedNode(out IOeNode3 node);
        new event SelectionChangedEventHandler2 SelectionChanged;
    }

}