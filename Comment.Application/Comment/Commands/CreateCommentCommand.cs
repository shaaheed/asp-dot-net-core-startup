using Msi.Mediator.Abstractions;

namespace Comment.Application.Comment.Commands
{
    public class CreateCommentCommand : ICommand<object>
    {
        public string Content { get; set; }
    }
}
