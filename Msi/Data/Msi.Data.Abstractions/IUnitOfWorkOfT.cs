using Msi.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Data.Abstractions
{
    public interface IUnitOfWork<TDataContext> where TDataContext : IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IRepository<TSet> GetRepository<TSet>() where TSet : class, IEntity;
    }
}
