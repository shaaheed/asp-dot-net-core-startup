using System.Threading;
using System.Threading.Tasks;

namespace Core.Events
{
    public interface IEventBus
    {
        Task Publish<TEvent>(TEvent[] events, CancellationToken cancellationToken = default) where TEvent : IEvent;

    }
}
