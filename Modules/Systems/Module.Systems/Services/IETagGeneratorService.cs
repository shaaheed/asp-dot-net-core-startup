using Msi.Service.Abstractions;

namespace Module.Systems.Services
{
    public interface IETagGeneratorService : IService
    {
        string GetETag(string key, byte[] contentBytes);

        string GetETag(byte[] contentBytes);

        string GetETag(object data);
    }
}
