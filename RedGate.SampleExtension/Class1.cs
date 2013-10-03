using System;
using System.Reflection;
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
            

            //m_Provider4.AddToolsMenuItem(new Command());

            m_Provider4.AddGlobalCommand(new SharedCommand(m_Provider4));

            m_Provider4.MenuBar.MainMenu.BeginSubmenu("Sample", "Sample")
                .BeginSubmenu("Sub 1", "Sub1")
                    .AddCommand("RedGate_Sample_Command")
                    .AddCommand("RedGate_Sample_Command")
                .EndSubmenu()
                .BeginSubmenu("Sub 2", "Sub2")
                    //.AddCommand("Command3")
                    //.AddCommand("Command4")
                .EndSubmenu();

            
            m_Provider4.AddToolbarItem(new Command());

            m_Provider4.AddTopLevelMenuItem(new Submenu(subMenus));
        }

        public void OnNodeChanged(ObjectExplorerNodeDescriptorBase node)
        {
            //Called when object explorer node selection changes.
        }

        public string Version { get { return "RedGate.Sample 1.0"; } }
    }

    public class SharedCommand : ISharedCommandWithExecuteParameter
    {
        private readonly ISsmsFunctionalityProvider4 m_Provider;
        private readonly ICommandImage m_CommandImage = new CommandImageNone();

        public SharedCommand(ISsmsFunctionalityProvider4 provider)
        {
            m_Provider = provider;
        }

        public string Name { get { return "RedGate_Sample_Command"; } }
        public void Execute(object parameter)
        {
            m_Provider.QueryWindow.OpenNew("hello");
        }

        public string Caption { get { return "Red Gate Sample Command"; } }
        public string Tooltip { get { return "Tooltip"; }}
        public ICommandImage Icon { get { return m_CommandImage; } }
        public string[] DefaultBindings { get { return new[] { "global::Ctrl+Alt+D" }; } }
        public bool Visible { get { return true; } }
        public bool Enabled { get { return true; } }


        public void Execute()
        {
            
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
            return true;
        }

        public override string ItemText
        {
            get { return m_Label; }
        }

        public override void OnAction(ObjectExplorerNodeDescriptorBase node)
        {
            var oeNode = (IOeNode) node;
            if (oeNode == null)
            {
                m_Provider4.QueryWindow.OpenNew("null");
                return;
            }
            m_Provider4.QueryWindow.OpenNew(string.Format("Name: {0}\nPath: {1}", oeNode.Name, oeNode.Path));
        }
    }
}
