using Module.Permissions.Entities;
using System.Collections.Generic;
using Module.Permissions.Shared;
using static Module.Constructions.Domain.PermissionIds;
using static Module.Constructions.Domain.PermissionGroupIds;
using Msi.Data.Abstractions;

namespace Module.Constructions.Domain
{
    public class ProjectPermissionSeeder : AbstractSeeder<Permission>
    {
        public override int Order => 1;

        public override IEnumerable<Permission> GetSeeds()
        {
            return new List<Permission>()
                .Create(ProjectCreate, PermissionCodes.ProjectCreate, Project)
                .Update(ProjectUpdate, PermissionCodes.ProjectUpdate, Project)
                .List(ProjectList, PermissionCodes.ProjectList, Project)
                .Delete(ProjectDelete, PermissionCodes.ProjectDelete, Project)
                .View(ProjectView, PermissionCodes.ProjectView, Project)
                .FullAccess(ProjectFullAccess, PermissionCodes.ProjectFullAccess, Project);
        }
    }
}
