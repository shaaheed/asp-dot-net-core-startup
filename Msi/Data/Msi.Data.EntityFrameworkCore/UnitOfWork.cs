using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Msi.Core;
using Msi.Data.Abstractions;
using Msi.Data.Entity;
using Msi.Service.App;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Data.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly IDataContext _dataContext;
        private readonly Dictionary<Type, object> _repositories;
        //private readonly IEventBus _eventBus;
        private readonly IDbConnection _dbConnection;
        private readonly DbContext _dbContext;
        private IDbContextTransaction _transaction;

        private Action<object> _onBeforeSaveChanges;
        private Action<object> _onAfterSaveChanges;
        private readonly ServiceFactory _serviceFactory;
        private readonly IAppService _appService;

        private readonly DateTime _now;
        public UnitOfWork(
            IDataContext dataContext,
            IAppService appService,
            ServiceFactory serviceFactory
            /*,IEventBus eventBus*/)
        {
            _now = DateTime.Now;
            Console.WriteLine("UOW " + _now);
            if (!(dataContext is DbContext))
                throw new ArgumentException($"The {nameof(dataContext)} object must be an instance of the Microsoft.EntityFrameworkCore.DbContext class.");

            //_eventBus = eventBus;
            _dataContext = dataContext;
            _dbContext = _dataContext as DbContext;
            _appService = appService;
            _repositories = new Dictionary<Type, object>();
            _dbConnection = _dbContext.Database.GetDbConnection();
            _serviceFactory = serviceFactory;

            string httpMethod = _appService.GetHttpMethod();
            if (!string.IsNullOrEmpty(httpMethod) && httpMethod != "GET")
            {
                _transaction = _dbContext.Database.BeginTransaction();
            } 
        }

        public void OnBeforeSaveChangesAsync(Action<object> action)
        {
            _onBeforeSaveChanges = action;
        }

        public void OnAfterSaveChangesAsync(Action<object> action)
        {
            _onAfterSaveChanges = action;
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var entries = _dbContext.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                var entity = entry.Entity as IEntity;
                PipelineHandlerDelegate<IEntity> handler = () => Task.FromResult(entity);

                var pipelineType = typeof(IUnitOfWorkPipeline<>).MakeGenericType(entry.Entity.GetType());
                var pipelines = _serviceFactory.GetInstances(pipelineType);

                if (pipelines != null)
                {
                    foreach (var pipeline in pipelines.Reverse())
                    {
                        var r = pipeline as IUnitOfWorkPipeline<IEntity>;
                        if (r != null)
                        {

                        }
                    }
                    //var x = await pipelines.Reverse().Aggregate(handler, (next, pipeline) => () =>
                    //{
                    //    var d = pipeline as dynamic;
                    //    //var dd = d.Hello();
                    //    var d2 = pipeline.Handle(entity, cancellationToken, next);
                    //    return d2;
                    //})();
                }
            }

            //var entries = _dataContext.GetChangeTrackerEntities<BaseEntity>().ToArray();

            foreach (var entry in entries)
            {
                if (entry.Entity is IAuditableEntity<Guid>)
                {
                    var entity = (IAuditableEntity<Guid>)entry.Entity;
                    if (entry.State == EntityState.Modified)
                    {
                        entity.UpdatedAt = DateTimeOffset.UtcNow;
                    }
                    else if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = DateTimeOffset.UtcNow;
                        entity.UpdatedAt = DateTimeOffset.UtcNow;
                    }
                }
                if (entry.Entity is IOrganizationEntity)
                {
                    var organizationId = _appService.GetOrganizationId();
                    if (!string.IsNullOrEmpty(organizationId))
                    {
                        var organizationGuid = new Guid(organizationId);
                        var entity = (IOrganizationEntity)entry.Entity;
                        if (entry.State == EntityState.Added)
                        {
                            entity.OrganizationId = organizationGuid;
                        }
                        else if (entry.State == EntityState.Modified && entity.OrganizationId != organizationGuid)
                        {
                            throw new Exception("Permission denied.");
                        }
                        
                    }
                }
            }

            int result;
            try
            {
                result = await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }

            //foreach (var entry in entries)
            //{
            //    _onAfterSaveChanges.Invoke(entry.Entity);
            //}

            // ignore events if no dispatcher provided
            //if (_eventBus == null) return result;

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

            var repository = new Repository<TSet>(_dataContext, _appService);
            _repositories.Add(typeof(TSet), repository);
            return repository;
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                _transaction = await _dbContext.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction != null)
            {
                try
                {
                    await _transaction.CommitAsync(cancellationToken);
                }
                catch
                {
                    await _transaction.RollbackAsync(cancellationToken);
                    await _transaction.DisposeAsync();
                }
            }
        }

        public Task RollBackAsync(CancellationToken cancellationToken = default)
        {
            return _transaction?.RollbackAsync(cancellationToken);
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_dbConnection.ConnectionString);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
            _transaction?.Dispose();
            _dbConnection?.Dispose();
        }
    }
}
