using Msi.Mediator.Abstractions;

namespace Comment.Application.Comment.Commands
{
    public class DeleteCommentCommand : ICommand<object>
    {
        public long Id { get; set; }
    }
}
