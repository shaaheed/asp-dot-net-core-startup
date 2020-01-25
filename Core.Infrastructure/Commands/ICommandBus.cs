using System.Threading;
using System.Threading.Tasks;

namespace Core.Infrastructure.Commands
{
    public interface ICommandBus
    {
        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
    }
}
