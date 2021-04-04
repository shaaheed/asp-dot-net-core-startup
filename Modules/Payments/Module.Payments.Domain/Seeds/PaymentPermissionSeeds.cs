//using Core.Interfaces.Data;
//using Module.Permissions.Entities;
//using System.Collections.Generic;
//using static Module.Payments.Common.Permissions;

//namespace Module.Payments.Data
//{
//    public class PaymentPermissionSeeds : ISeed<Permission>
//    {
//        public int Order => 0;
//        public IEnumerable<Permission> GetSeeds()
//        {
//            return new List<Permission>
//            {
//                new Permission {
//                    Id = PaymentCreate,
//                    Name = "Create",
//                    Group = Group.Payment
//                },
//                new Permission {
//                    Id = PaymentUpdate,
//                    Name = "Update",
//                    Group = Group.Payment
//                },
//                new Permission {
//                    Name = "View",
//                    Id = PaymentView,
//                    Group = Group.Payment
//                },
//                new Permission {
//                    Name = "List",
//                    Id = PaymentList,
//                    Group = Group.Payment
//                },
//                new Permission {
//                    Id = PaymentDelete,
//                    Name = "Delete",
//                    Group = Group.Payment
//                },
//                new Permission {
//                    Id = PaymentManage,
//                    Name = "Manage",
//                    Group = Group.Payment
//                }
//            };
//        }
//    }
//}
