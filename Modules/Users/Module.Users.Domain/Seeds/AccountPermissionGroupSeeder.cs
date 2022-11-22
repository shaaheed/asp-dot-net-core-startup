using Module.Permissions.Entities;
using System.Collections.Generic;
using Msi.Data.Abstractions;
using static Module.Accounts.Domain.PermissionGroupIds;

namespace Module.Accounts.Domain
{
    public class AccountPermissionGroupSeeder : AbstractSeeder<PermissionGroup>
    {
        public override IEnumerable<PermissionGroup> GetSeeds()
        {
            return new List<PermissionGroup>() {
                new PermissionGroup(User, "User")
            };
        }
    }
}
