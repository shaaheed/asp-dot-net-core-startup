using System.Threading;
using System.Threading.Tasks;

namespace Msi.Mediator.Abstractions
{
    public interface ICommandBus
    {
        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
    }
}
