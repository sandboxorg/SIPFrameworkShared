namespace RedGate.SIPFrameworkShared
{
    public abstract class ActionSimpleOeMenuItemBase : SimpleOeMenuItemBase
    {
        public abstract void OnAction(ObjectExplorerNodeDescriptorBase node);
    }

    public abstract class ActionSimpleOeMenuItemBase2 : ActionSimpleOeMenuItemBase
    {
        public virtual bool EnabledFor(ObjectExplorerNodeDescriptorBase oeNode) { return true; }
        public virtual bool CheckedFor(ObjectExplorerNodeDescriptorBase oeNode) { return false; }
    }
}
