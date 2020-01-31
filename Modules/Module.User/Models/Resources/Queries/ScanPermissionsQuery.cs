using Core.Infrastructure.Queries;
using System;

namespace Modules.User.Resources.Queries
{
    public class ScanPermissionsQuery : IQuery<object>
    {
        public Type PermissionAttributeType { get; set; }
    }
}
