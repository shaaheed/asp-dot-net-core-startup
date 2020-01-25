using MediatR;

namespace Core.Events
{
    public interface IEventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
    {

    }
}
