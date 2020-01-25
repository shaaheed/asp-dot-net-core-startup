// Copyright © 2015 Sahidul Islam. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Core.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Msi.Extensions.Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Extensions.Persistence.EntityFrameworkCore
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {

        private readonly DbContext _dataContext;

        public Repository(IDataContext dataContext)
        {
            _dataContext = dataContext as DbContext;
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
            return _dataContext.Set<TEntity>().FirstOrDefaultAsync(predicate, cancellationToken);
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

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dataContext.SaveChangesAsync(cancellationToken);
        }

        public Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dataContext.Set<TEntity>().SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _dataContext.Set<TEntity>().Update(entity);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataContext.Set<TEntity>().Where(predicate);
        }
    }
}
