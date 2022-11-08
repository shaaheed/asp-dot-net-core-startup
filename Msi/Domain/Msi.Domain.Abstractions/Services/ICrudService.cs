using Msi.Mediator.Abstractions;
using Msi.Utilities.Filter;

namespace Msi.Domain.Abstractions
{
    public interface ICrudService<TEntity> where TEntity : new()
    {
        Task<TResponse> Create<TResponse>(ICreateCommand<TResponse> command, CancellationToken cancellationToken = default);

        Task<TResponse> Update<TResponse>(IUpdateCommand<TResponse> command, CancellationToken cancellationToken = default);

        Task<TResponse> Delete<TResponse>(IDeleteCommand<TResponse> command, CancellationToken cancellationToken = default);

        Task<TResponse> Get<TResponse>(ISingleQuery<TResponse> query, CancellationToken cancellationToken = default);

        Task<TResponse> Gets<TResponse>(IPagedQuery<TResponse> query, CancellationToken cancellationToken = default) where TResponse : PagedCollection<TResponse>;
    }
}
