//using Core.Interfaces.Data;
//using Module.Users.Entities;
//using System.Collections.Generic;
//using static Module.Sales.Common.Permissions;

//namespace Module.Sales.Data
//{
//    public class SalesRolePermissionSeeds : ISeed<RolePermission>
//    {
//        public int Order => 1;
//        public IEnumerable<RolePermission> GetSeeds()
//        {
//            return new List<RolePermission>
//            {
//                new RolePermission { Id = 600, RoleId = 1, PermissionId = CustomerManage },
//                new RolePermission { Id = 601, RoleId = 1, PermissionId = InvoiceManage },
//                new RolePermission { Id = 602, RoleId = 1, PermissionId = ProductManage },
//                new RolePermission { Id = 603, RoleId = 1, PermissionId = InvoicePaymentManage },
//                new RolePermission { Id = 604, RoleId = 1, PermissionId = VendorManage },
//                new RolePermission { Id = 605, RoleId = 1, PermissionId = QouteManage },
//                new RolePermission { Id = 606, RoleId = 1, PermissionId = BillManage }
//            };
//        }
//    }
//}
