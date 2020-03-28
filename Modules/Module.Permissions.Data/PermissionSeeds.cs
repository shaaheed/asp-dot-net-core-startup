using Core.Interfaces.Data;
using Module.Permissions.Entities;
using System.Collections.Generic;
using static Module.Permissions.Common.Permissions;

namespace Module.Permissions.Data
{
    public class PermissionSeeds : ISeed<Permission>
    {
        public int Order => 0;
        public IEnumerable<Permission> GetSeeds()
        {
            return new List<Permission>
            {
                new Permission {
                    Id = PermissionCreate,
                    Name = "Create",
                    Group = Group.Permission
                },
                new Permission {
                    Id = PermissionUpdate,
                    Name = "Update",
                    Group = Group.Permission
                },
                new Permission {
                    Name = "View",
                    Id = PermissionView,
                    Group = Group.Permission
                },
                new Permission {
                    Name = "List",
                    Id = PermissionList,
                    Group = Group.Permission
                },
                new Permission {
                    Id = PermissionDelete,
                    Name = "Delete",
                    Group = Group.Permission
                }
            };
        }
    }
}
