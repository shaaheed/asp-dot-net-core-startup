using Msi.Mediator.Abstractions;
using Msi.Utilities.Filter;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Domain.Abstractions
{
    public static class QueryExtensions
    {
        public static Task<TResponse> SendAsync<TResponse>(this IQueryBus queryBus, IQuery<TResponse> query, IPagingOptions pagingOptions = default, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            if(query is Query<TResponse>)
            {
                var baseQuery = (Query<TResponse>)query;
                baseQuery.PagingOptions = pagingOptions;
                baseQuery.SearchOptions = searchOptions;

            }
            return queryBus.SendAsync(query, cancellationToken);
        }
    }
}
