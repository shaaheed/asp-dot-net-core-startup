using Module.Permissions.Entities;
using System.Collections.Generic;
using Module.Permissions.Shared;
using Msi.Data.Abstractions;

namespace Module.Permissions.Data
{
    public class PermissionGroupSeeder : AbstractSeeder<PermissionGroup>
    {
        public override IEnumerable<PermissionGroup> GetSeeds()
        {
            return new List<PermissionGroup>() {
                new PermissionGroup(PermissionGroupIds.Permission, "Permission")
            };
        }
    }
}
