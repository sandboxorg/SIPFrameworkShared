namespace RedGate.SIPFrameworkShared
{
    public interface ISsmsAddin
    {
        void OnLoad(ISsmsExtendedFunctionalityProvider provider);
        void OnNodeChanged(ObjectExplorerNodeDescriptorBase node);
        string Version { get; }
    }

    public interface ISimpleSsmsAddin
    {
        void OnLoad(ISsmsFunctionalityProvider provider);
        void OnNodeChanged(ObjectExplorerNodeDescriptorBase node);
        string Version { get; }
    }

    public class SimpleSsmsAddInAdapter : ISsmsAddin
    {
        private readonly ISimpleSsmsAddin m_SimpleSsmsAddin;

        public SimpleSsmsAddInAdapter(ISimpleSsmsAddin simpleSsmsAddin)
        {
            m_SimpleSsmsAddin = simpleSsmsAddin;
        }

        public void OnLoad(ISsmsExtendedFunctionalityProvider provider)
        {
            m_SimpleSsmsAddin.OnLoad(provider);
        }

        public void OnNodeChanged(ObjectExplorerNodeDescriptorBase node)
        {
            m_SimpleSsmsAddin.OnNodeChanged(node);
        }

        public string Version
        {
            get { return m_SimpleSsmsAddin.Version; }
        }
    }
}
