using System.Drawing;

namespace RedGate.SIPFrameworkShared
{
    public abstract class DynamicListSimpleOeMenuItemBase : SimpleOeMenuItemBase
    {
        // TODO this should be IEnumerable, because that's covariant.
        abstract public SimpleOeMenuItemBase[] GetApplicableChildren(ObjectExplorerNodeDescriptorBase oeNode);

        public override Image ItemImage
        {
            get { return null; }
        }

        public override string ItemText
        {
            get { return string.Empty; }
        }
    }
}