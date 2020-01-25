using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Comment.Application.Comment.Events
{
    public class CommentEventHandler : INotificationHandler<CommentCreatedEvent>
    {
        public Task Handle(CommentCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}
