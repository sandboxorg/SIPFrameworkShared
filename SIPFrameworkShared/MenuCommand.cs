using System;

namespace RedGate.SIPFrameworkShared
{
    public abstract class ContextMenuCommand : ISharedCommand
    {
        public string Name { get; private set; }
        public string Caption { get; private set; }
        public string Tooltip { get; private set; }
        public ICommandImage Icon { get; private set; }
        public string[] DefaultBindings { get; set; }
        public bool Visible{ get; set; }
        public bool Enabled { get; set; }

        /// <param name="name">The unqualified name SSMS uses internally to refer to this command.</param>
        /// <param name="caption">The caption text displayed for the item.</param>
        /// <param name="tooltip">The tooltip displayed for the item.</param>
        public ContextMenuCommand(string name, string caption, string tooltip)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (caption == null) throw new ArgumentNullException("caption");
            if (tooltip == null) throw new ArgumentNullException("tooltip");
            Name = name;
            Caption = caption;
            Tooltip = tooltip;
            DefaultBindings = new string[0];
        }

        public abstract void Execute();
    }
}
