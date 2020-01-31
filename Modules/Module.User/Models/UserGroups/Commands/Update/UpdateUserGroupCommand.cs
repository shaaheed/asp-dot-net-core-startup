using Core.Infrastructure.Commands;
using Core.Infrastructure.Responses;

namespace Application.UserGroups.Commands
{
    public class UpdateUserGroupCommand : ICommand<CommandResponse<long>>
    {
        public long Id { get; set; }
        public string Name { get; set; }

    }

}
