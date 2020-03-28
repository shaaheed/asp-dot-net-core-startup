﻿using Core.Interfaces.Data;
using Module.Users.Entities;
using System.Collections.Generic;
using static Module.Organizations.Common.Permissions;

namespace Module.Organizations.Data
{
    public class OrganizationRolePermissionSeeds : ISeed<RolePermission>
    {
        public int Order => 1;
        public IEnumerable<RolePermission> GetSeeds()
        {
            return new List<RolePermission>
            {
                new RolePermission { Id = 300, RoleId = 1, PermissionId = OrganizationManage }
            };
        }
    }
}
