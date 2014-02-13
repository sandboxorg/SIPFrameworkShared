using System.Drawing;

namespace RedGate.SIPFrameworkShared
{
    public abstract class SimpleOeMenuItemBase
    {
        public abstract string ItemText { get; }
        public virtual Image ItemImage { get { return null; } }
        public abstract bool AppliesTo(ObjectExplorerNodeDescriptorBase oeNode);
    }
}