using Msi.Utilities.Filter;

namespace Msi.Mediator.Abstractions
{
    public interface IPagedQuery<TResponse> : IQuery<TResponse> where TResponse : PagedCollection<TResponse>
    {
    }
}
