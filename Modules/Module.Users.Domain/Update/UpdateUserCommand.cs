using Core.Infrastructure.Commands;
using Core.Infrastructure.Responses;

namespace Module.Users.Domain
{
    public class UpdateUserCommand : ICommand<CommandResponse<long>>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long[] UserGroupIds { get; set; }

    }

}
