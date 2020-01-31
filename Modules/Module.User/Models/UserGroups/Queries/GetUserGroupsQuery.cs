using Module.Users.Entities;
using Core.Infrastructure.Queries;
using System.Collections.Generic;

namespace Application.UserGroups.Queries
{
    public class GetUserGroupsQuery : IQuery<ICollection<UserGroup>>
    {
    }
}
