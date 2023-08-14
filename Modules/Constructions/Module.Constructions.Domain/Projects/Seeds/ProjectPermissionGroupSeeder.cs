using Module.Permissions.Entities;
using System.Collections.Generic;
using Msi.Data.Abstractions;
using static Module.Constructions.Domain.PermissionGroupIds;

namespace Module.Constructions.Domain
{
    public class ProjectPermissionGroupSeeder : AbstractSeeder<PermissionGroup>
    {
        public override IEnumerable<PermissionGroup> GetSeeds()
        {
            return new List<PermissionGroup>() {
                new PermissionGroup(Project, "Project")
            };
        }
    }
}
