using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Module.Permissions.Domain
{
    public class GetPermissionsQuery : IQuery<IEnumerable<PermissionDto>>
    {
    }
}
