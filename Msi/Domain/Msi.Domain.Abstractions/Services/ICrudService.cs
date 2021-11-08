using Msi.Mediator.Abstractions;
using Msi.Service.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Domain.Abstractions
{
    public interface ICrudService<TEntity> : IScopedService where TEntity : new()
    {
        Task<TResponse> Create<TResponse>(ICreateCommand<TEntity, TResponse> command, CancellationToken cancellationToken = default);

        Task<TResponse> Update<TResponse>(IUpdateCommand<TEntity, TResponse> command, CancellationToken cancellationToken = default);

        Task<TResponse> Delete<TResponse>(IDeleteCommand<TEntity, TResponse> command, CancellationToken cancellationToken = default);

        Task<TResponse> Get<TResponse>(ISingleQuery<TEntity, TResponse> query, CancellationToken cancellationToken = default);

        Task<TResponse> Gets<TResponse>(PagedQuery<TEntity, TResponse> query, CancellationToken cancellationToken = default);
    }
}
