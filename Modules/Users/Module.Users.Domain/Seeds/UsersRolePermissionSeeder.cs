using Module.Accounts.Entities;
using Msi.Data.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Accounts.Domain
{
    public class UsersRolePermissionSeeder : AbstractSeeder<RolePermission>
    {
        public override int Order => 1;
        public override IEnumerable<RolePermission> GetSeeds()
        {
            return new List<RolePermission>
            {
                new RolePermission {
                    Id = new Guid("11d9ebe0-aee8-4940-974b-ff31f73dafda"),
                    RoleId = new Guid("a4bc7ff6-4da2-4e5f-8e77-e50ceaa5e74c"),
                    PermissionId = PermissionIds.UserFullAccess
                }
            };
        }
    }
}
