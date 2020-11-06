using Module.Permissions.Entities;
using System.Collections.Generic;
using Msi.Data.Entity;
using Module.Permissions.Shared;
using static Module.Organizations.Domain.PermissionIds;
using static Module.Organizations.Domain.PermissionGroupIds;

namespace Module.Organizations.Domain
{
    public class OrganizationPermissionSeeds : ISeed<Permission>
    {
        public int Order => 0;
        public IEnumerable<Permission> GetSeeds()
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
