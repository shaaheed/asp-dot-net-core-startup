using Core.Interfaces.Data;
using Module.Permissions.Entities;
using System.Collections.Generic;
using static Module.Core.Common.Permissions;

namespace Module.Core.Data
{
    public class PermissionSeeds : ISeed<Permission>
    {
        public int Order => 0;

        public IEnumerable<Permission> GetSeeds()
        {
            return new List<Permission>
            {
                #region Currency
                new Permission {
                    Id = CurrencyCreate,
                    Name = "Create",
                    Group = Group.Currency
                },
                new Permission {
                    Id = CurrencyUpdate,
                    Name = "Update",
                    Group = Group.Currency
                },
                new Permission {
                    Id = CurrencyView,
                    Name = "View",
                    Group = Group.Currency
                },
                new Permission {
                    Id = CurrencyList,
                    Name = "List",
                    Group = Group.Currency
                },
                new Permission {
                    Id = CurrencyDelete,
                    Name = "Delete",
                    Group = Group.Currency
                },
                new Permission {
                    Id = CurrencyManage,
                    Name = "Manage",
                    Group = Group.Currency
                },
                #endregion
            };
        }
    }
}
