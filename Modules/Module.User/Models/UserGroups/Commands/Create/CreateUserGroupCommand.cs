using Core.Infrastructure.Commands;
using Core.Infrastructure.Responses;

namespace Application.UserGroups.Commands
{
    public class CreateUserGroupCommand : ICommand<CommandResponse<long>>
    {
        public string Name { get; set; }

    }

}
