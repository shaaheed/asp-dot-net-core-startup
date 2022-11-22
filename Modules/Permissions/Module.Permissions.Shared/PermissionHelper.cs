using Module.Permissions.Entities;
using System;
using System.Collections.Generic;

namespace Module.Permissions.Shared
{
    public static class PermissionHelper
    {

        public static Permission Create(Guid id, string code, Guid groupId)
        {
            return Permission(id, code, "Create", groupId);
        }

        public static Permission Update(Guid id, string code, Guid groupId)
        {
            return Permission(id, code, "Update", groupId);
        }

        public static Permission View(Guid id, string code, Guid groupId)
        {
            return Permission(id, code, "View", groupId);
        }

        public static Permission Delete(Guid id, string code, Guid groupId)
        {
            return Permission(id, code, "Delete", groupId);
        }

        public static Permission List(Guid id, string code, Guid groupId)
        {
            return Permission(id, code, "List", groupId);
        }

        public static Permission FullAccess(Guid id, string code, Guid groupId)
        {
            return Permission(id, code, "Full Access", groupId);
        }

        public static List<Permission> Create(this List<Permission> permissions, Guid permissionId, string permissionCode, Guid groupId)
        {
            permissions.Add(Create(permissionId, permissionCode, groupId));
            return permissions;
        }

        public static List<Permission> Update(this List<Permission> permissions, Guid permissionId, string permissionCode, Guid groupId)
        {
            permissions.Add(Update(permissionId, permissionCode, groupId));
            return permissions;
        }

        public static List<Permission> View(this List<Permission> permissions, Guid permissionId, string permissionCode, Guid groupId)
        {
            permissions.Add(View(permissionId, permissionCode, groupId));
            return permissions;
        }

        public static List<Permission> Delete(this List<Permission> permissions, Guid permissionId, string permissionCode, Guid groupId)
        {
            permissions.Add(Delete(permissionId, permissionCode, groupId));
            return permissions;
        }

        public static List<Permission> List(this List<Permission> permissions, Guid permissionId, string permissionCode, Guid groupId)
        {
            permissions.Add(List(permissionId, permissionCode, groupId));
            return permissions;
        }

        public static List<Permission> FullAccess(this List<Permission> permissions, Guid permissionId, string permissionCode, Guid groupId)
        {
            permissions.Add(FullAccess(permissionId, permissionCode, groupId));
            return permissions;
        }

        public static Permission Permission(Guid permissionId, string permissionCode, string name, Guid groupId)
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
