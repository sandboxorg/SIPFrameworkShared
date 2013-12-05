namespace RedGate.SIPFrameworkShared
{
    /// <summary>
    /// Your Addin should implement either ISsmsAddin or ISimpleSsmsAddin. These were created and named
    /// before the backwards compatibility scheme was worked out. It does not matter which you implement.
    /// Since you can cast the functionality provider to the version you want.
    /// </summary>
    public interface ISsmsAddin
    {
        void OnLoad(ISsmsExtendedFunctionalityProvider provider);
        void OnNodeChanged(ObjectExplorerNodeDescriptorBase node);
        string Version { get; }
    }

    /// <summary>
    /// Your Addin should implement either ISsmsAddin or ISimpleSsmsAddin. These were created and named
    /// before the backwards compatibility scheme was worked out. It does not matter which you implement.
    /// Since you can cast the functionality provider to the version you want.
    /// </summary>
    public interface ISimpleSsmsAddin
    {
        void OnLoad(ISsmsFunctionalityProvider provider);
        void OnNodeChanged(ObjectExplorerNodeDescriptorBase node);
        string Version { get; }
    }

    /// <summary>
    /// This should not be used.
    /// </summary>
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
