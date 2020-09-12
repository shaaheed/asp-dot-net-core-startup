using MediatR;

namespace Msi.Mediator.Abstractions
{
    public interface IEventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
    {

    }
}
