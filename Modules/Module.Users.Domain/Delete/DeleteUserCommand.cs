using Core.Infrastructure.Commands;
using Core.Infrastructure.Responses;

namespace Module.Users.Domain
{
    public class DeleteUserCommand : ICommand<CommandResponse<long>>
    {
        public long Id { get; set; }

    }

}
