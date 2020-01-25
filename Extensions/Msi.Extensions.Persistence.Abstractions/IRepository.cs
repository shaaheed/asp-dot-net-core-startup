using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Extensions.Persistence.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        TEntity Remove(TEntity entity);

        void AttachRange(IEnumerable<TEntity> entities);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        //Task<bool> ExistAsync(long id);

        //bool Exist(long? id);

        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        //IQueryable<TEntity> Match(ICriteria<TEntity> criteria, bool readOnly = true);

        //Task<TEntity> MatchSingleAsync(ISingleCriteria<TEntity> criteria, bool readOnly = true);

        //IQueryable<TViewModel> Match<TViewModel>(IViewModelCriteria<TEntity, TViewModel> criteria, bool readOnly = true);

        IQueryable<TEntity> AsQueryable();
    }
}
