using Msi.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Msi.Data.Abstractions
{
    public interface ICriteria<TEntity, TResponse>
        where TEntity : IEntity
    {

        Task<TResponse> MatchAsync(IQueryable<TEntity> query, bool readOnly = false);

    }
}
