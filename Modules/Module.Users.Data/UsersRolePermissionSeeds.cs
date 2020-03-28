using Core.Interfaces.Data;
using Module.Users.Entities;
using System.Collections.Generic;
using static Module.Users.Common.Permissions;

namespace Module.Users.Data
{
    public class UsersRolePermissionSeeds : ISeed<RolePermission>
    {
        public int Order => 1;
        public IEnumerable<RolePermission> GetSeeds()
        {
            return new List<RolePermission>
            {
                new RolePermission { Id = 700, RoleId = 1, PermissionId = UserManage }
            };
        }
    }
}
