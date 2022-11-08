using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Accounts.Domain
{
    public class GetRolesQuery : Query<PagedCollection<RoleDto>>
    {
    }
}
