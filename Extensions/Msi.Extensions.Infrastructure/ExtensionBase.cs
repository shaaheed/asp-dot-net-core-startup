namespace Msi.Extensions.Infrastructure
{
    public abstract class ExtensionBase : IExtension
    {
        public virtual string Name => GetType().FullName;
        public virtual string Description => null;
        public virtual string Url => null;
        public virtual string Version => null;
        public virtual string Authors => null;
    }
}
