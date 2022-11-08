using Msi.Mediator.Abstractions;
using Msi.Utilities.Filter;

namespace Msi.Domain.Abstractions
{
    public abstract class PagedQuery<TResponse> : IPagedQuery<TResponse>
        where TResponse : PagedCollection<TResponse>, new()
    {
    }
}
