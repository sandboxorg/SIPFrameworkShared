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

        /// <summary>
        /// The version of your addin as a string
        /// </summary>
        string Version { get; }
    }

    public interface ISsmsAddin3 : ISsmsAddin
    {
        /// <summary>
        /// A long description of the purpose of your addin
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The name of your addin
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Who is responsible for creating the addin
        /// </summary>
        string Author { get; }

        /// <summary>
        /// The addins webpage URL
        /// </summary>
        string Url { get; }
    }

    public interface ISsmsAddin4 : ISsmsAddin3
    {
        /// <summary>
        /// Notification that SSMS is beginning to shutdown.
        /// </summary>
        void OnShutdown();
    }

    public interface ISsmsAddin5 : ISsmsAddin4
    {
        /// <summary>
        /// SSMS has shutdown. Last chance to release resources.
        /// </summary>
        void OnDisconnect();
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
