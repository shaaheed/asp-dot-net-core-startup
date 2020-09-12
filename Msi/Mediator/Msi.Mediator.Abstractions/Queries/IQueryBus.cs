using System.Threading;
using System.Threading.Tasks;

namespace Msi.Mediator.Abstractions
{
    public interface IQueryBus
    {
        Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
    }
}
