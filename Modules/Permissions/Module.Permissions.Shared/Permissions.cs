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
        public const long PermissionCreate = 100;
        public const long PermissionUpdate = 101;
        public const long PermissionView = 102;
        public const long PermissionDelete = 103;
        public const long PermissionList = 104;
        public const long PermissionFullAccess = 105;
    }

    public static partial class PermissionGroupIds
    {
        public const long Permission = 100;
    }
}
