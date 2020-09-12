using System.Threading;
using System.Threading.Tasks;

namespace Msi.Mediator.Abstractions
{
    public interface IEventBus
    {
        Task Publish<TEvent>(TEvent[] events, CancellationToken cancellationToken = default) where TEvent : IEvent;

    }
}
