using Msi.Mediator.Abstractions;

namespace Comment.Application.Comment.Events
{
    public class CommentCreatedEvent : IEvent
    {
        public long Id { get; set; }
        public string Content { get; set; }
    }
}
