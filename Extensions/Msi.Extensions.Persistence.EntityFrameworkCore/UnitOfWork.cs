using Core.Events;
using Core.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Msi.Extensions.Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Extensions.Persistence.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly IDataContext _dataContext;
        private readonly Dictionary<Type, object> _repositories;
        private readonly IEventBus _eventBus;
        private readonly IDbContextTransaction _transaction;

        public UnitOfWork(
            IDataContext dataContext,
            IEventBus eventBus)
        {

            if (!(dataContext is DbContext))
                throw new ArgumentException($"The {nameof(dataContext)} object must be an instance of the Microsoft.EntityFrameworkCore.DbContext class.");

            _transaction = (dataContext as DbContext).Database.BeginTransaction();
            _eventBus = eventBus;
            _dataContext = dataContext;
            _repositories = new Dictionary<Type, object>();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            //var entries = _dataContext.GetChangeTrackerEntities<BaseEntity>().ToArray();

            //foreach (var entry in entries)
            //{
            //if (entry.State == EntityState.Modified)
            //{
            //    entry.Entity.SetValue(DateTime.UtcNow, "UpdatedAt");
            //}
            //if (entry.State == EntityState.Added)
            //{
            //    entry.Entity.SetValue(DateTime.UtcNow, "CreatedAt");
            //    entry.Entity.SetValue(DateTime.UtcNow, "UpdatedAt");
            //}
            //}

            var result = (_dataContext as DbContext).SaveChangesAsync(cancellationToken);

            // ignore events if no dispatcher provided
            if (_eventBus == null) return result;

            //foreach (var entity in entries)
            //{
            //var events = entity.Events.ToArray();
            //entity.Events.Clear();
            //foreach (var domainEvent in events)
            //{
            //    await _dispatcher.Dispatch(domainEvent).ConfigureAwait(false);
            //}
            //}

            return result;
        }

        public IRepository<TSet> GetRepository<TSet>() where TSet : class, IEntity
        {
            if (_repositories.ContainsKey(typeof(TSet)))
            {
                return _repositories[typeof(TSet)] as IRepository<TSet>;
            }

            var repository = new Repository<TSet>(_dataContext);
            _repositories.Add(typeof(TSet), repository);
            return repository;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await _transaction.RollbackAsync(cancellationToken);
            }
        }

        public void Dispose()
        {
            (_dataContext as DbContext).Dispose();
            _transaction.Dispose();
        }
    }
}
