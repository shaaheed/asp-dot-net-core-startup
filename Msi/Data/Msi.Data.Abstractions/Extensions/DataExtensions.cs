using Msi.Data.Entity;
using Msi.Utilities.Expressions;
using Msi.Utilities.Filter;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Data.Abstractions
{
    public static class DataExtensions
    {

        private static IUnitOfWork _uow => UnitOfWorkAccessor.Instance;
        private static PropertyInfo IsDeletedPropery = typeof(BaseEntity).GetProperty("IsDeleted");
        private static PropertyInfo UpdatedAtPropery = typeof(BaseEntity).GetProperty("UpdatedAt");

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

        public static async Task<PagedCollection<TViewModel>> ListAsync<TEntity, TViewModel>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
            where TEntity : IEntity
            where TViewModel : class
        {
            
            query = ApplyDeleteQuery(query); //query = query.Where(x => !x.IsDeleted);

            if (predicate != null)
                query = query.Where(predicate);

            query = query.ApplySearch(searchOptions);
            query = ApplyOrderByDecending(query); //.OrderByDescending(x => x.UpdatedAt);

            var countQuery = query; //.Select(x => x.Id);
            var total = await Task.Run(() => countQuery.Count(), cancellationToken);

            query = query.ApplyPagination(pagingOptions);

            var results = query.Select(selector);
            var items = await Task.Run(() => results.ToList(), cancellationToken);

            var result = new PagedCollection<TViewModel>(items, total, pagingOptions);
            return result;
        }

        public static Task<PagedCollection<TViewModel>> ListAsync<TEntity, TViewModel>(this IRepository<TEntity> repository, Expression<Func<TEntity, TViewModel>> selector, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
            where TEntity : RootEntity
            where TViewModel : class
        {
            var result = repository.AsReadOnly().ListAsync(null,
                selector,
                pagingOptions,
                searchOptions,
                cancellationToken);

            return result;
        }

        public static Task<PagedCollection<TViewModel>> ListAsync<TEntity, TViewModel>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
            where TEntity : RootEntity
            where TViewModel : class
        {
            var result = repository.AsReadOnly().ListAsync(predicate,
                selector,
                pagingOptions,
                searchOptions,
                cancellationToken);

            return result;
        }

        //public static Task<PagedCollection<IdNameViewModel>> ListAsync<T>(this IRepository<T> repository, Expression<Func<T, bool>> predicate, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        //    where T : IdNameEntity
        //{
        //    var selector = DynamicSelect<T>(new HashSet<string> { "Id", "Name", "IsDeleted" });
        //    var x = repository.AsReadOnly().Select(selector).ToList();

        //    return repository.ListAsync(predicate,
        //        IdNameViewModel.Select<T>(),
        //        pagingOptions,
        //        searchOptions,
        //        cancellationToken);
        //}

        public static Task<PagedCollection<TViewModel>> ListAsync<TEntity, TViewModel>(this IUnitOfWork unitOfWork, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
           where TEntity : RootEntity
           where TViewModel : class
        {
            var repository = unitOfWork.GetRepository<TEntity>();

            return repository.ListAsync(predicate,
                selector,
                pagingOptions,
                searchOptions,
                cancellationToken);
        }

        public static Task<PagedCollection<TViewModel>> ListAsync<TEntity, TViewModel>(this IUnitOfWork unitOfWork, Expression<Func<TEntity, TViewModel>> selector, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
           where TEntity : RootEntity
           where TViewModel : class
        {
            var repository = unitOfWork.GetRepository<TEntity>();

            return repository.ListAsync(null,
                selector,
                pagingOptions,
                searchOptions,
                cancellationToken);
        }

        //public static Task<PagedCollection<IdNameViewModel>> ListAsync<TEntity>(this IUnitOfWork unitOfWork, Expression<Func<TEntity, bool>> predicate, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        //    where TEntity : IdNameEntity
        //{
        //    var repository = unitOfWork.GetRepository<TEntity>();

        //    return repository.ListAsync(predicate,
        //        pagingOptions,
        //        searchOptions,
        //        cancellationToken);
        //}

        public static async Task<TViewModel> GetAsync<TEntity, TViewModel>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, CancellationToken cancellationToken = default)
            where TEntity : RootEntity
            where TViewModel : class
        {
            query = ApplyDeleteQuery(query); // query.Where(x => !x.IsDeleted);

            if (predicate != null)
                query = query.Where(predicate);

            var results = query.Select(selector);
            var item = await Task.Run(() => results.FirstOrDefault(), cancellationToken);

            if (item == null)
                throw new Exception("Item not found");

            return item;
        }

        public static Task<TViewModel> GetAsync<TEntity, TViewModel>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, CancellationToken cancellationToken = default)
            where TEntity : RootEntity
            where TViewModel : class
        {
            return repository.AsReadOnly().GetAsync(predicate,
                selector,
                cancellationToken);
        }

        //public static Task<IdNameViewModel> GetAsync<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        //    where TEntity : IdNameEntity
        //{
        //    return repository.GetAsync(predicate,
        //        IdNameViewModel.Select<TEntity>(),
        //        cancellationToken);
        //}

        public static Task<TViewModel> GetAsync<TEntity, TViewModel>(this IUnitOfWork unitOfWork, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, CancellationToken cancellationToken = default)
            where TEntity : RootEntity
            where TViewModel : class
        {
            var repository = unitOfWork.GetRepository<TEntity>();
            return repository.GetAsync(predicate, selector, cancellationToken);
        }

//public static Task<IdNameViewModel> GetAsync<TEntity>(this IUnitOfWork unitOfWork, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        //    where TEntity : IdNameEntity
        //{
        //    var repository = unitOfWork.GetRepository<TEntity>();

        //    return repository.GetAsync(predicate,
        //        IdNameViewModel.Select<TEntity>(),
        //        cancellationToken);
        //}

        //public static async Task<bool> DeleteAsync<TEntity, TPropertyType>(this IUnitOfWork unitOfWork, TPropertyType id, CancellationToken cancellationToken = default)
        //    where TEntity : BaseEntity<TPropertyType>
        //{
        //    var repository = unitOfWork.GetRepository<TEntity>();
        //    var entity = await repository.Where(x => x.Id == id && !x.IsDeleted);
        //    // FirstOrDefault

        //    if (entity == null)
        //        throw new Exception("Item not found");

        //    entity.IsDeleted = true;
        //    var result = await unitOfWork.SaveChangesAsync(cancellationToken);

        //    return result > 0;
        //}

        public static async Task<long> CreateAsync<TEntity>(this IUnitOfWork unitOfWork, TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : BaseEntity
        {
            var repository = unitOfWork.GetRepository<TEntity>();
            await repository.AddAsync(entity, cancellationToken);

            var result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }

        public static Expression<Func<TEntity, dynamic>> DynamicSelect<TEntity>(ISet<string> fields)
        {
            var x = Expression.Parameter(typeof(TEntity), "x");

            var members = fields.Select(p => Expression.PropertyOrField(x, p));

            var addMethod = typeof(IDictionary<string, object>).GetMethod(
                        "Add", new Type[] { typeof(string), typeof(object) });

            var elements = members.Select(e => Expression.ElementInit(addMethod, Expression.Constant(e.Member.Name), Expression.Convert(e, typeof(object))));

            var n = Expression.New(typeof(ExpandoObject));
            var list = Expression.ListInit(n, elements);

            var lambda = Expression.Lambda<Func<TEntity, dynamic>>(list, x);
            return lambda;
        }

        public static async Task UpdateAsync<TEntity, TKey>(this IRepository<TEntity> repository, IEnumerable<TKey> inputs, Expression<Func<TEntity, bool>> searchAllIdPredicate, Expression<Func<TEntity, TKey>> allIdSelector, Func<TKey, TEntity> newEntitySelector, Func<IEnumerable<TKey>, Expression<Func<TEntity, bool>>> deletedEntityPredicate) where TEntity : RootEntity
        {
            var allQuery = repository.AsReadOnly();
            allQuery = ApplyDeleteQuery(allQuery); // .Where(x => !x.IsDeleted);

            if (searchAllIdPredicate != null)
                allQuery = allQuery.Where(searchAllIdPredicate);

            var allIds = await Task.Run(() => allQuery.Select(allIdSelector).ToList());

            // new
            var newItems = inputs.Except(allIds).Select(newEntitySelector);
            await repository.AddRangeAsync(newItems);

            // deleted
            var deletedIds = allIds.Except(inputs);
            var deletedQuery = repository.AsQueryable();
            deletedQuery = ApplyDeleteQuery(deletedQuery); // .Where(x => !x.IsDeleted);

            if (deletedEntityPredicate != null)
            {
                var deletedEntityPredicateExpression = deletedEntityPredicate(deletedIds);
                deletedQuery = deletedQuery.Where(deletedEntityPredicateExpression);
            }

            var deletedItems = await Task.Run(() => deletedQuery.ToList());
            repository.RemoveRange(deletedItems);
        }

        public static PaginateQueryBuilder<TEntity, TViewModel> Paginate<TEntity, TViewModel>(this IRepository<TEntity> repository, IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
            where TEntity : BaseEntity
            where TViewModel : class
        {
            var builder = new PaginateQueryBuilder<TEntity, TViewModel>()
                .Repository(repository)
                .PagingOptions(pagingOptions)
                .SearchOptions(searchOptions);
            return builder;
        }

        public static IQueryable<T> ApplyDeleteQuery<T>(IQueryable<T> query)
        {
            if (typeof(BaseEntity).IsAssignableFrom(typeof(T)))
            {
                var parameter = ExpressionUtilities.Parameter<T>("x");
                var left = parameter.GetPropertyExpression(IsDeletedPropery);
                var right = Expression.Constant(false, IsDeletedPropery.PropertyType);
                var expression = Expression.Equal(left, right);
                var lambda = ExpressionUtilities.GetLambda<T, bool>(parameter, expression);
                query = query.DynamicWhere(lambda);
            }
            return query;
        }

        public static IQueryable<T> ApplyOrderByDecending<T>(IQueryable<T> query)
        {
            if (typeof(BaseEntity).IsAssignableFrom(typeof(T)))
            {
                var parameter = ExpressionUtilities.Parameter<T>("x");
                var left = Expression.MakeMemberAccess(parameter, UpdatedAtPropery);
                var lambda = ExpressionUtilities.GetLambda<T, DateTimeOffset?>(parameter, left);
                query = query.DynamicOrderByDescending(lambda, typeof(DateTimeOffset?));
            }
            return query;
        }

    }

    public class PaginateQueryBuilder<TEntity, TViewModel>
        where TEntity : BaseEntity
        where TViewModel : class
    {
        private IRepository<TEntity> _repository;
        private IPagingOptions _pagingOptions;
        private ISearchOptions _searchOptions;
        private IQueryable<TEntity> _query;
        private Expression<Func<TEntity, bool>> _predicate;
        private Expression<Func<TEntity, TViewModel>> _selector;

        public PaginateQueryBuilder<TEntity, TViewModel> Repository(IRepository<TEntity> repository)
        {
            _repository = repository;
            _query = repository.AsReadOnly();
            return this;
        }

        public PaginateQueryBuilder<TEntity, TViewModel> PagingOptions(IPagingOptions pagingOptions)
        {
            _pagingOptions = pagingOptions;
            return this;
        }

        public PaginateQueryBuilder<TEntity, TViewModel> SearchOptions(ISearchOptions searchOptions)
        {
            _searchOptions = searchOptions;
            return this;
        }

        public PaginateQueryBuilder<TEntity, TViewModel> Where(Expression<Func<TEntity, bool>> predicate)
        {
            _predicate = predicate;
            return this;
        }

        public PaginateQueryBuilder<TEntity, TViewModel> Select(Expression<Func<TEntity, TViewModel>> selector)
        {
            _selector = selector;
            return this;
        }

        public Task<PagedCollection<TViewModel>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return _query.ListAsync(_predicate, _selector, _pagingOptions, _searchOptions, cancellationToken);
        }

    }
}
