using Core.Infrastructure.Queries;
using System.Collections.Generic;

namespace Module.Permissions.Domain
{
    public class GetPermissionsQuery : IQuery<IEnumerable<PermissionDto>>
    {
    }
}
