using RedGate.SIPFrameworkShared;

namespace RedGate.SampleExtension
{
    class Submenu : SubmenuSimpleOeMenuItemBase
    {
        public Submenu(SimpleOeMenuItemBase[] subMenus)
            : base(subMenus)
        {
        }

        public override string ItemText
        {
            get { return "SampleExtension"; }
        }

        public override bool AppliesTo(ObjectExplorerNodeDescriptorBase oeNode)
        {
            return GetApplicableChildren(oeNode).Length > 0;
        }
    }
}