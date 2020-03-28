using Core.Interfaces.Data;
using Module.Permissions.Entities;
using System.Collections.Generic;
using static Module.Organizations.Common.Permissions;

namespace Module.Organizations.Data
{
    public class OrganizationPermissionSeeds : ISeed<Permission>
    {
        public int Order => 0;
        public IEnumerable<Permission> GetSeeds()
        {
            return new List<Permission>
            {
                new Permission {
                    Id = OrganizationCreate,
                    Name = "Create",
                    Group = Group.Organization
                },
                new Permission {
                    Id = OrganizationUpdate,
                    Name = "Update",
                    Group = Group.Organization
                },
                new Permission {
                    Name = "View",
                    Id = OrganizationView,
                    Group = Group.Organization
                },
                new Permission {
                    Name = "List",
                    Id = OrganizationList,
                    Group = Group.Organization
                },
                new Permission {
                    Id = OrganizationDelete,
                    Name = "Delete",
                    Group = Group.Organization
                },
                new Permission {
                    Id = OrganizationManage,
                    Name = "Manage",
                    Group = Group.Organization
                }
            };
        }
    }
}
