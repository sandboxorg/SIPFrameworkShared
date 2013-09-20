using System;
using RedGate.SIPFrameworkShared;

namespace RedGate.SampleExtension
{
    public class Extension : ISsmsAddin
    {
        private ISsmsFunctionalityProvider4 m_Provider4;
        private object m_Dte2;

        public void OnLoad(ISsmsExtendedFunctionalityProvider provider)
        {
            m_Provider4 = (ISsmsFunctionalityProvider4) provider;
            
            m_Dte2 = m_Provider4.SsmsDte2;

            if(m_Provider4 == null)
                throw new ArgumentException();

            var subMenus = new SimpleOeMenuItemBase[]
                {
                    new Menu("Command 1", m_Provider4),
                    new Menu("Command 2", m_Provider4),
                };
            m_Provider4.AddTopLevelMenuItem(new Submenu(subMenus));
        }

        public void OnNodeChanged(ObjectExplorerNodeDescriptorBase node)
        {
            //Called when object explorer node selection changes.
        }

        public string Version { get { return "RedGate.Sample 1.0"; } }
    }

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

    public class Menu : ActionSimpleOeMenuItemBase
    {
        private readonly string m_Label;
        private readonly ISsmsFunctionalityProvider4 m_Provider4;

        public Menu(string label, ISsmsFunctionalityProvider4 provider4)
        {
            m_Label = label;
            m_Provider4 = provider4;
        }

        public override bool AppliesTo(ObjectExplorerNodeDescriptorBase oeNode)
        {
            var oe100Node = oeNode as IOe100Node;
            return oe100Node != null && oe100Node.Path == @"Server/Database/Table/Trigger";
        }

        public override string ItemText
        {
            get { return m_Label; }
        }

        public override void OnAction(ObjectExplorerNodeDescriptorBase node)
        {
            m_Provider4.QueryWindow.OpenNew("stuff");
        }
    }
}
