using Msi.Data.Entity;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Data.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IRepository<TSet> GetRepository<TSet>() where TSet : class, IEntity;

        Task BeginTransactionAsync();

        Task CommitAsync(CancellationToken cancellationToken = default);

        Task RollBackAsync(CancellationToken cancellationToken = default);

        IDbConnection GetConnection();

        void OnBeforeSaveChangesAsync(Action<object> action);

        void OnAfterSaveChangesAsync(Action<object> action);
    }
}
