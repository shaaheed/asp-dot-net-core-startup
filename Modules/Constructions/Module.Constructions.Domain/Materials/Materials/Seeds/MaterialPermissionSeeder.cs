using Module.Permissions.Entities;
using System.Collections.Generic;
using Module.Permissions.Shared;
using static Module.Constructions.Domain.PermissionIds;
using static Module.Constructions.Domain.PermissionGroupIds;
using Msi.Data.Abstractions;

namespace Module.Constructions.Domain
{
    public class MaterialPermissionSeeder : AbstractSeeder<Permission>
    {
        public override int Order => 1;

        public override IEnumerable<Permission> GetSeeds()
        {
            return new List<Permission>()
                .Create(MaterialCreate, PermissionCodes.MaterialCreate, Material)
                .Update(MaterialUpdate, PermissionCodes.MaterialUpdate, Material)
                .List(MaterialList, PermissionCodes.MaterialList, Material)
                .Delete(MaterialDelete, PermissionCodes.MaterialDelete, Material)
                .View(MaterialView, PermissionCodes.MaterialView, Material)
                .FullAccess(MaterialFullAccess, PermissionCodes.MaterialFullAccess, Material);
        }
    }
}
