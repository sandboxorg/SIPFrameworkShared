using System;

namespace RedGate.SIPFrameworkShared
{
    public interface ISharedCommand
    {
        /// <summary>
        /// The command name. Must be constant! Must not contain spaces
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Called to perform the ICommand's action.
        /// </summary>
        void Execute();

        /// <summary>
        /// The UI text to display for this command (e.g. menu text or button caption)
        /// </summary>
        string Caption { get; }
        /// <summary>
        /// The tooltip text to display for this command
        /// </summary>
        string Tooltip { get; }

        /// <summary>
        /// The Icon for the command.
        /// </summary>
        ICommandImage Icon { get; }

        /// <summary>
        /// The default key bindings to give this command. Provides 0 or more
        /// key binding strings in Visual Studio format (e.g. "global::Ctrl+Shift+D").
        /// </summary>
        string[] DefaultBindings { get; }

        bool Visible { get; }
        bool Enabled { get; }
    }
}