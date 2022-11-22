using System;

namespace Module.Permissions.Shared
{
    public static partial class PermissionCodes
    {
        public const string PermissionCreate = "permissions.create";
        public const string PermissionUpdate = "permissions.update";
        public const string PermissionView = "permissions.view";
        public const string PermissionDelete = "permissions.delete";
        public const string PermissionList = "permissions.list";
        public const string PermissionFullAccess = "permissions.full.access";
    }

    public static partial class PermissionIds
    {
        public static Guid PermissionCreate = new Guid("1df285f7-38f6-46a4-ab05-a8cf248202c5");
        public static Guid PermissionUpdate = new Guid("e4733687-c554-4014-b9ee-80574cad4a09");
        public static Guid PermissionView = new Guid("40360b32-b63d-4f7a-9f38-00ce12a79a5d");
        public static Guid PermissionDelete = new Guid("45ec8733-66ff-4c98-8ba7-f3fde8470d51");
        public static Guid PermissionList = new Guid("31f7dd66-7c9e-4ed7-9bf7-a6a5844065a2");
        public static Guid PermissionFullAccess = new Guid("e7074cfa-0d12-4681-9298-15017b10def3");
    }

    public static partial class PermissionGroupIds
    {
        public static Guid Permission = new Guid("83da8805-b880-4145-a256-c18aed24ef36");
    }
}
