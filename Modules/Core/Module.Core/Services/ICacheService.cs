using Msi.Service;
using System;
using System.Threading.Tasks;

namespace Module.Core.Services
{
    public interface ICacheService : IService
    {
        Task<(bool, T)> GetData<T>(Func<Task<T>> data);
    }
}
