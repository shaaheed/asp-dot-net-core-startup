// Copyright © 2020 Sahidul Islam. All rights reserved.

using Microsoft.EntityFrameworkCore;
using Msi.Data.Abstractions;
using Msi.Data.Entity;
using Msi.Service.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Data.EntityFrameworkCore
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {

        private readonly DbContext _dataContext;
        private readonly IAppService _appService;

        public Repository(
            IDataContext dataContext,
            IAppService appService)
        {
            _dataContext = dataContext as DbContext;
            _appService = appService;
        }

        public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return _dataContext.Set<TEntity>().AddAsync(entity, cancellationToken).AsTask();
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return _dataContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dataContext.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> AsReadOnly()
        {
            return _dataContext.Set<TEntity>().AsQueryable().AsNoTracking();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dataContext.Set<TEntity>().CountAsync(predicate, cancellationToken);
        }

        public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dataContext.Set<TEntity>().LongCountAsync(predicate, cancellationToken);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dataContext
                .Set<TEntity>()
                .FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public Task<TEntity> FirstOrDefaultAsyncAsReadOnly(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dataContext
                .Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public Task<TViewModel> FirstOrDefaultAsyncAsReadOnly<TViewModel>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, CancellationToken cancellationToken = default)
        {
            return _dataContext
                .Set<TEntity>()
                .AsNoTracking()
                .Where(predicate)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task<TViewModel> FirstOrDefaultAsync<TViewModel>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, CancellationToken cancellationToken = default)
        {
            return _dataContext
                .Set<TEntity>()
                .Where(predicate)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public TEntity Remove(TEntity entity)
        {
            return _dataContext.Set<TEntity>().Remove(entity).Entity;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dataContext.Set<TEntity>().RemoveRange(entities);
        }

        public void AttachRange(IEnumerable<TEntity> entities)
        {
            _dataContext.Set<TEntity>().AttachRange(entities);
        }

        public void Attach(TEntity entity)
        {
            if (entity is IHaveOrganizationEntity)
            {
                var _entity = entity as IHaveOrganizationEntity;
                _entity.OrganizationId = new Guid(_appService.GetOrganizationId());
            }
            _dataContext.Set<TEntity>().Attach(entity);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dataContext.SaveChangesAsync(cancellationToken);
        }

        public Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate, bool readOnly = false, CancellationToken cancellationToken = default)
        {
            var set = _dataContext.Set<TEntity>();
            if (readOnly)
                set.AsNoTracking();

            return set.SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _dataContext.Set<TEntity>().Update(entity);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataContext
                .Set<TEntity>()
                .Where(predicate);
        }

        public IQueryable<TEntity> WhereAsReadOnly(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataContext
                .Set<TEntity>()
                .AsNoTracking()
                .Where(predicate);
        }

        public Task<List<TViewModel>> ListAsync<TViewModel>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, CancellationToken cancellationToken = default)
        {
            return _dataContext
                .Set<TEntity>()
                .Where(predicate)
                .Select(selector)
                .ToListAsync(cancellationToken);
        }

        public Task<List<TViewModel>> ListAsyncAsReadOnly<TViewModel>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, CancellationToken cancellationToken = default)
        {
            return _dataContext
                .Set<TEntity>()
                .AsNoTracking()
                .Where(predicate)
                .Select(selector)
                .ToListAsync(cancellationToken);
        }

        public Task<TResponse> MatchAsync<TResponse>(ICriteria<TEntity, TResponse> criteria)
        {
            var set = _dataContext.Set<TEntity>();
            return criteria.MatchAsync(set);
        }
    }
}
