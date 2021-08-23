using Msi.Mediator.Abstractions;
using Msi.Utilities.Filter;

namespace Msi.Domain.Abstractions
{
    public class Query<TResponse> : IQuery<TResponse>
    {
        public IFilterOptions FilterOptions { get; set; }

        public Query()
        {
            //
        }

        public Query<TResponse> AddFilterOptions(IFilterOptions filterOptions)
        {
            FilterOptions = filterOptions;
            return this;
        }
    }
}
