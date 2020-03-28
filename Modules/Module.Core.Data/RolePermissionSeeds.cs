using Core.Interfaces.Data;
using Module.Users.Entities;
using System.Collections.Generic;
using static Module.Core.Common.Permissions;

namespace Module.Core.Data
{
    public class RolePermissionSeeds : ISeed<RolePermission>
    {
        public int Order => 1;

        public IEnumerable<RolePermission> GetSeeds()
        {
            return new List<RolePermission>
            {
                new RolePermission { Id = 200, RoleId = 1, PermissionId = CurrencyManage }
            };
        }
    }
}
