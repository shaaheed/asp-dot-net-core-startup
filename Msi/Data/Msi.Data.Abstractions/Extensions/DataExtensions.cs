using Msi.Data.Entity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Data.Abstractions
{
    public static class DataExtensions
    {

        private static IUnitOfWork _uow => UnitOfWorkAccessor.Instance;

        public static IEntity Remove<TEntity>(this TEntity entity) where TEntity : class, IEntity
        {
            return entity.GetRepository().Remove(entity);
        }

        public static void Remove<TEntity>(this IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            entities.GetRepository().RemoveRange(entities);
        }

        public static Task AddAsync<TEntity>(this TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IEntity
        {
            return entity.GetRepository().AddAsync(entity, cancellationToken);
        }

        public static Task AddAsync<TEntity>(this IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class, IEntity
        {
            return entities.GetRepository().AddRangeAsync(entities, cancellationToken);
        }

        public static async Task<int> SaveAsync<TEntity>(this TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IEntity
        {
            await entity.AddAsync(cancellationToken);
            var rowsAffected = await _uow.SaveChangesAsync(cancellationToken);
            return rowsAffected;
        }

        public static async Task<int> SaveAsync<TEntity>(this IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class, IEntity
        {
            await entities.AddAsync(cancellationToken);
            var rowsAffected = await _uow.SaveChangesAsync(cancellationToken);
            return rowsAffected;
        }

        public static IRepository<TEntity> GetRepository<TEntity>(this TEntity entity) where TEntity : class, IEntity
        {
            return _uow.GetRepository<TEntity>();
        }

        public static IRepository<TEntity> GetRepository<TEntity>(this IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            return _uow.GetRepository<TEntity>();
        }

    }
}
