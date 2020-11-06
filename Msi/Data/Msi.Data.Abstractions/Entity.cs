using Msi.Data.Entity;
using System.Linq;

namespace Msi.Data.Abstractions
{
    [IgnoredEntity]
    public class Entity : IEntity
    {

        private static IUnitOfWork _uow = UnitOfWorkAccessor.Instance;

        public static IQueryable<TEntity> All<TEntity>() where TEntity : class, IEntity
        {
            return _uow.GetRepository<TEntity>().AsQueryable();
        }

    }
}
