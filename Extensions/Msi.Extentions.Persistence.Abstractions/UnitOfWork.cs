using Core.Events;
using Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Extensions.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IEFDataContext _dataContext;
        private readonly Dictionary<Type, object> _repositories;
        private readonly IEventBus _eventBus;

        public UnitOfWork(
            IEFDataContext dataContext,
            IEventBus eventBus)
        {
            _eventBus = eventBus;
            _dataContext = dataContext;
            _repositories = new Dictionary<Type, object>();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var entries = _dataContext.GetChangeTrackerEntities<BaseEntity>().ToArray();

            foreach (var entry in entries)
            {
                //if (entry.State == EntityState.Modified)
                //{
                //    entry.Entity.SetValue(DateTime.UtcNow, "UpdatedAt");
                //}
                //if (entry.State == EntityState.Added)
                //{
                //    entry.Entity.SetValue(DateTime.UtcNow, "CreatedAt");
                //    entry.Entity.SetValue(DateTime.UtcNow, "UpdatedAt");
                //}
            }

            var result = _dataContext.SaveChangesAsync(cancellationToken);

            // ignore events if no dispatcher provided
            if (_eventBus == null) return result;

            foreach (var entity in entries)
            {
                //var events = entity.Events.ToArray();
                //entity.Events.Clear();
                //foreach (var domainEvent in events)
                //{
                //    await _dispatcher.Dispatch(domainEvent).ConfigureAwait(false);
                //}
            }

            return result;
        }

        public IRepository<TSet> GetRepository<TSet>() where TSet : class, IEntity
        {
            if (_repositories.ContainsKey(typeof(TSet)))
            {
                return _repositories[typeof(TSet)] as IRepository<TSet>;
            }

            var repository = new EFRepository<TSet>(_dataContext);
            _repositories.Add(typeof(TSet), repository);
            return repository;
        }

    }
}
