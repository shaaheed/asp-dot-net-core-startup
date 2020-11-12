using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Users.Domain
{
    public class GetUsersQuery : Query<PagedCollection<UserDto>>
    {
    }
}
