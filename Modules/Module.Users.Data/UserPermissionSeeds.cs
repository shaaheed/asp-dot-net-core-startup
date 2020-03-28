using Core.Interfaces.Data;
using Module.Permissions.Entities;
using System.Collections.Generic;
using static Module.Users.Common.Permissions;

namespace Module.Users.Data
{
    public class UserPermissionSeeds : ISeed<Permission>
    {
        public int Order => 0;
        public IEnumerable<Permission> GetSeeds()
        {
            return new List<Permission>
            {
                #region Customer
                new Permission {
                    Id = UserCreate,
                    Name = "Create",
                    Group = Group.User
                },
                new Permission {
                    Id = UserUpdate,
                    Name = "Update",
                    Group = Group.User
                },
                new Permission {
                    Id = UserView,
                    Name = "View",
                    Group = Group.User
                },
                new Permission {
                    Id = UserList,
                    Name = "List",
                    Group = Group.User
                },
                new Permission {
                    Id = UserDelete,
                    Name = "Delete",
                    Group = Group.User
                },
                new Permission {
                    Id = UserManage,
                    Name = "Manage",
                    Group = Group.User
                },
                #endregion
            };
        }
    }
}
