using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Mediator.Abstractions
{
    public class EventBus : IEventBus
    {

        private readonly IMediator _mediator;

        public EventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Publish<TEvent>(TEvent[] events, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            if (events != null)
            {
                foreach (var @event in events)
                {
                    _mediator.Publish(@event, cancellationToken);
                }
            }
            return Task.CompletedTask;
        }


    }
}
