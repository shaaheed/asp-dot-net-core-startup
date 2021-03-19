using Msi.Service;
using System;
using System.Threading.Tasks;

namespace Module.Systems.Services
{
    public interface ICacheService : IService
    {
        Task<(bool, T)> GetData<T>(Func<Task<T>> data);
    }
}
