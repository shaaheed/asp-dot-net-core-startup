using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Domain.Abstractions
{
    public class CrudService<TEntity> : ICrudService<TEntity> where TEntity : new()
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public CrudService(
            ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        public Task<TResponse> Create<TResponse>(ICreateCommand<TEntity, TResponse> command, CancellationToken cancellationToken = default)
        {
            return _commandBus.SendAsync(command, cancellationToken);
        }

        public Task<TResponse> Delete<TResponse>(IDeleteCommand<TEntity, TResponse> command, CancellationToken cancellationToken = default)
        {
            return _commandBus.SendAsync(command, cancellationToken);
        }

        public Task<TResponse> Get<TResponse>(ISingleQuery<TEntity, TResponse> query, CancellationToken cancellationToken = default)
        {
            return _queryBus.SendAsync(query, cancellationToken);
        }

        public Task<TResponse> Gets<TResponse>(PagedQuery<TEntity, TResponse> query, CancellationToken cancellationToken = default)
        {
            return _queryBus.SendAsync(query, cancellationToken);
        }

        public Task<TResponse> Update<TResponse>(IUpdateCommand<TEntity, TResponse> command, CancellationToken cancellationToken = default)
        {
            return _commandBus.SendAsync(command, cancellationToken);
        }
    }
}
