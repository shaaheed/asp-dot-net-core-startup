using Msi.Mediator.Abstractions;
using Msi.Utilities.Filter;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Domain.Abstractions
{
    public static class QueryExtensions
    {
        public static Task<TResponse> SendAsync<TResponse>(this IQueryBus queryBus, IQuery<TResponse> query, IFilterOptions filterOptions = default, CancellationToken cancellationToken = default)
        {
            if(query is Query<TResponse>)
            {
                var baseQuery = (Query<TResponse>)query;
                baseQuery.FilterOptions = filterOptions;
            }
            return queryBus.SendAsync(query, cancellationToken);
        }
    }
}
