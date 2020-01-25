using Core.Infrastructure.Commands;

namespace Comment.Application.Comment.Commands
{
    public class DeleteCommentCommand : ICommand<object>
    {
        public long Id { get; set; }
    }
}
