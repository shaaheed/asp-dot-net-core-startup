using Module.Permissions.Entities;
using System.Collections.Generic;

namespace Module.Permissions.Shared
{
    public static class PermissionHelper
    {

        public static Permission Create(long id, string code, long groupId)
        {
            return Permission(id, code, "Create", groupId);
        }

        public static Permission Update(long id, string code, long groupId)
        {
            return Permission(id, code, "Update", groupId);
        }

        public static Permission View(long id, string code, long groupId)
        {
            return Permission(id, code, "View", groupId);
        }

        public static Permission Delete(long id, string code, long groupId)
        {
            return Permission(id, code, "Delete", groupId);
        }

        public static Permission List(long id, string code, long groupId)
        {
            return Permission(id, code, "List", groupId);
        }

        public static Permission FullAccess(long id, string code, long groupId)
        {
            return Permission(id, code, "Full Access", groupId);
        }

        public static List<Permission> Create(this List<Permission> permissions, long permissionId, string permissionCode, long groupId)
        {
            permissions.Add(Create(permissionId, permissionCode, groupId));
            return permissions;
        }

        public static List<Permission> Update(this List<Permission> permissions, long permissionId, string permissionCode, long groupId)
        {
            permissions.Add(Update(permissionId, permissionCode, groupId));
            return permissions;
        }

        public static List<Permission> View(this List<Permission> permissions, long permissionId, string permissionCode, long groupId)
        {
            permissions.Add(View(permissionId, permissionCode, groupId));
            return permissions;
        }

        public static List<Permission> Delete(this List<Permission> permissions, long permissionId, string permissionCode, long groupId)
        {
            permissions.Add(Delete(permissionId, permissionCode, groupId));
            return permissions;
        }

        public static List<Permission> List(this List<Permission> permissions, long permissionId, string permissionCode, long groupId)
        {
            permissions.Add(List(permissionId, permissionCode, groupId));
            return permissions;
        }

        public static List<Permission> FullAccess(this List<Permission> permissions, long permissionId, string permissionCode, long groupId)
        {
            permissions.Add(FullAccess(permissionId, permissionCode, groupId));
            return permissions;
        }

        public static Permission Permission(long permissionId, string permissionCode, string name, long groupId)
        {
            return new Permission
            {
                Id = permissionId,
                Code = permissionCode,
                Name = name,
                GroupId = groupId
            };
        }

    }
}
