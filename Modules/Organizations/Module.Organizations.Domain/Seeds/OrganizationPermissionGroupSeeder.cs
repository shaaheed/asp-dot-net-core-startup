using Module.Permissions.Entities;
using System.Collections.Generic;
using Msi.Data.Abstractions;
using static Module.Organizations.Domain.PermissionGroupIds;

namespace Module.Organizations.Domain
{
    public class OrganizationPermissionGroupSeeder : AbstractSeeder<PermissionGroup>
    {
        public override IEnumerable<PermissionGroup> GetSeeds()
        {
            return new List<PermissionGroup>() {
                new PermissionGroup(Organization, "Organization")
            };
        }
    }
}
