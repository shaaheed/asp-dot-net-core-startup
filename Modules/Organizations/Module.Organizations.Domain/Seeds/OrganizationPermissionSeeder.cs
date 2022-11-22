using Module.Permissions.Entities;
using System.Collections.Generic;
using Module.Permissions.Shared;
using static Module.Organizations.Domain.PermissionIds;
using static Module.Organizations.Domain.PermissionGroupIds;
using Msi.Data.Abstractions;

namespace Module.Organizations.Domain
{
    public class OrganizationPermissionSeeder : AbstractSeeder<Permission>
    {
        public override int Order => 1;

        public override IEnumerable<Permission> GetSeeds()
        {
            return new List<Permission>()
                .Create(OrganizationCreate, PermissionCodes.OrganizationCreate, Organization)
                .Update(OrganizationUpdate, PermissionCodes.OrganizationUpdate, Organization)
                .List(OrganizationList, PermissionCodes.OrganizationList, Organization)
                .Delete(OrganizationDelete, PermissionCodes.OrganizationDelete, Organization)
                .View(OrganizationView, PermissionCodes.OrganizationView, Organization)
                .FullAccess(OrganizationFullAccess, PermissionCodes.OrganizationFullAccess, Organization);
        }
    }
}
