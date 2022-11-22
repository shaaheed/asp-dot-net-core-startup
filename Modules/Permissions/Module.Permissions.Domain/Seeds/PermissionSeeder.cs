using Module.Permissions.Entities;
using System.Collections.Generic;
using Module.Permissions.Shared;
using static Module.Permissions.Shared.PermissionIds;
using Msi.Data.Abstractions;

namespace Module.Permissions.Data
{
    public class PermissionSeeder : AbstractSeeder<Permission>
    {
        public override int Order => 1;

        public override IEnumerable<Permission> GetSeeds()
        {
            return new List<Permission>()
                .Create(PermissionCreate, PermissionCodes.PermissionCreate, PermissionGroupIds.Permission)
                .Update(PermissionUpdate, PermissionCodes.PermissionUpdate, PermissionGroupIds.Permission)
                .View(PermissionView, PermissionCodes.PermissionView, PermissionGroupIds.Permission)
                .Delete(PermissionDelete, PermissionCodes.PermissionDelete, PermissionGroupIds.Permission)
                .List(PermissionList, PermissionCodes.PermissionList, PermissionGroupIds.Permission)
                .FullAccess(PermissionFullAccess, PermissionCodes.PermissionFullAccess, PermissionGroupIds.Permission);
        }
    }
}
