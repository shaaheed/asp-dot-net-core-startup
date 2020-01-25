using Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Extensions.Persistence
{
    public class UnitOfWork<TDataContext> : IUnitOfWork<TDataContext> where TDataContext : IEFDataContext
    {

        private readonly IEFDataContext _dataContext;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(IEFDataContext dataContext)
        {
            _dataContext = dataContext;
            _repositories = new Dictionary<Type, object>();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            //var entries = _dataContext.GetChangeTrackerEntries();

            //foreach (var entry in entries)
            //{
            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Entity.SetValue(DateTime.UtcNow, "UpdatedAt");
            //    }
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Entity.SetValue(DateTime.UtcNow, "CreatedAt");
            //        entry.Entity.SetValue(DateTime.UtcNow, "UpdatedAt");
            //    }
            //}

            return _dataContext.SaveChangesAsync(cancellationToken);
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
