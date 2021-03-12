//using Core.Interfaces.Data;
//using Module.Users.Entities;
//using System.Collections.Generic;
//using static Module.Accounting.Common.Permissions;

//namespace Module.Accounting.Data
//{
//    public class OrganizationRolePermissionSeeds : ISeed<RolePermission>
//    {
//        public int Order => 1;
//        public IEnumerable<RolePermission> GetSeeds()
//        {
//            return new List<RolePermission>
//            {
//                new RolePermission { Id = 100, RoleId = 1, PermissionId = ChartOfAccountManage },
//                new RolePermission { Id = 101, RoleId = 1, PermissionId = ChartOfAccountCategoryManage },
//                new RolePermission { Id = 102, RoleId = 1, PermissionId = TransactionManage }
//            };
//        }
//    }
//}
