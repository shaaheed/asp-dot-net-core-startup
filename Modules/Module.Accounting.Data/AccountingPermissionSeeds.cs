using Core.Interfaces.Data;
using Module.Permissions.Entities;
using System.Collections.Generic;
using static Module.Accounting.Common.Permissions;

namespace Module.Accounting.Data
{
    public class AccountingPermissionSeeds : ISeed<Permission>
    {
        public int Order => 0;
        public IEnumerable<Permission> GetSeeds()
        {
            return new List<Permission>
            {
                #region Chart Of Account
                new Permission {
                    Id = ChartOfAccountCreate,
                    Name = "Create",
                    Group = Group.ChartOfAccount
                },
                new Permission {
                    Id = ChartOfAccountUpdate,
                    Name = "Update",
                    Group = Group.ChartOfAccount
                },
                new Permission {
                    Name = "View",
                    Id = ChartOfAccountView,
                    Group = Group.ChartOfAccount
                },
                new Permission {
                    Name = "List",
                    Id = ChartOfAccountList,
                    Group = Group.ChartOfAccount
                },
                new Permission {
                    Id = ChartOfAccountDelete,
                    Name = "Delete",
                    Group = Group.ChartOfAccount
                },
                new Permission {
                    Id = ChartOfAccountManage,
                    Name = "Manage",
                    Group = Group.ChartOfAccount
                },
                #endregion

                #region Chart Of Account Category
                new Permission {
                    Id = ChartOfAccountCategoryCreate,
                    Name = "Create",
                    Group = Group.ChartOfAccountCategory
                },
                new Permission {
                    Id = ChartOfAccountCategoryUpdate,
                    Name = "Update",
                    Group = Group.ChartOfAccountCategory
                },
                new Permission {
                    Name = "View",
                    Id = ChartOfAccountCategoryView,
                    Group = Group.ChartOfAccountCategory
                },
                new Permission {
                    Name = "List",
                    Id = ChartOfAccountCategoryList,
                    Group = Group.ChartOfAccountCategory
                },
                new Permission {
                    Id = ChartOfAccountCategoryDelete,
                    Name = "Delete",
                    Group = Group.ChartOfAccountCategory
                },
                new Permission {
                    Id = ChartOfAccountCategoryManage,
                    Name = "Manage",
                    Group = Group.ChartOfAccountCategory
                },
                #endregion

                #region Transaction
                new Permission {
                    Id = TransactionCreate,
                    Name = "Create",
                    Group = Group.Transaction
                },
                new Permission {
                    Id = TransactionUpdate,
                    Name = "Update",
                    Group = Group.Transaction
                },
                new Permission {
                    Name = "View",
                    Id = TransactionView,
                    Group = Group.Transaction
                },
                new Permission {
                    Name = "List",
                    Id = TransactionList,
                    Group = Group.Transaction
                },
                new Permission {
                    Id = TransactionDelete,
                    Name = "Delete",
                    Group = Group.Transaction
                },
                new Permission {
                    Id = TransactionManage,
                    Name = "Manage",
                    Group = Group.Transaction
                }
                #endregion
            };
        }
    }
}
