using Msi.Service;

namespace Module.Core.Services
{
    public interface IETagGeneratorService : IService
    {
        string GetETag(string key, byte[] contentBytes);

        string GetETag(byte[] contentBytes);

        string GetETag(object data);
    }
}
