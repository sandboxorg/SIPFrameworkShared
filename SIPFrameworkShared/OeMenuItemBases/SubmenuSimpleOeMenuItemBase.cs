using System;

namespace RedGate.SIPFrameworkShared
{
    public abstract class SubmenuSimpleOeMenuItemBase: SimpleOeMenuItemBase
    {
        private readonly SimpleOeMenuItemBase[] m_Children;

        protected SubmenuSimpleOeMenuItemBase(params SimpleOeMenuItemBase[] children)
        {
            m_Children = children;
        }

        public override bool AppliesTo(ObjectExplorerNodeDescriptorBase oeNode)
        {
            foreach (var child in m_Children)
            {
                if (child.AppliesTo(oeNode))
                {
                    return true;
                }
            }
            return false;
        }

        public SimpleOeMenuItemBase[] GetApplicableChildren(ObjectExplorerNodeDescriptorBase oeNode)
        {
            return Array.FindAll(m_Children, c => c.AppliesTo(oeNode));
        }

        public SimpleOeMenuItemBase[] GetAllChildren()
        {
            return m_Children;
        }
    }
}