namespace Msi.Extensions.Infrastructure
{
    public interface IExtension
    {
        string Name { get; }
        string Description { get; }
        string Url { get; }
        string Version { get; }
        string Authors { get; }
    }
}
