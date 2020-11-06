using Msi.Mediator.Abstractions;
using Msi.Utilities.Filter;

namespace Msi.Domain.Abstractions
{
    public class Query<TResponse> : IQuery<TResponse>
    {
        public IPagingOptions PagingOptions { get; set; }
        public ISearchOptions SearchOptions { get; set; }

        public Query()
        {
            //
        }

        public Query(IPagingOptions pagingOptions, ISearchOptions searchOptions)
        {
            PagingOptions = pagingOptions;
            SearchOptions = searchOptions;
        }

        public Query<TResponse> AddPagingOptions(IPagingOptions pagingOptions)
        {
            PagingOptions = pagingOptions;
            return this;
        }

        public Query<TResponse> AddSearchOptions(ISearchOptions searchOptions)
        {
            SearchOptions = searchOptions;
            return this;
        }
    }
}
