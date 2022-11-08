namespace Module.Accounts.Domain
{
    public static partial class PermissionCodes
    {
        public const string UserCreate = "users.create";
        public const string UserUpdate = "users.update";
        public const string UserView = "users.view";
        public const string UserDelete = "users.delete";
        public const string UserList = "users.list";
        public const string UserFullAccess = "users.full.access";

        public const string RoleCreate = "roles.create";
        public const string RoleUpdate = "roles.update";
        public const string RoleView = "roles.view";
        public const string RoleDelete = "roles.delete";
        public const string RoleList = "roles.list";
        public const string RoleFullAccess = "roles.full.access";
    }

    public static partial class PermissionIds
    {
        public const long UserCreate = 200;
        public const long UserUpdate = 201;
        public const long UserView = 202;
        public const long UserDelete = 203;
        public const long UserList = 204;
        public const long UserFullAccess = 205;

        public const long RoleCreate = 300;
        public const long RoleUpdate = 301;
        public const long RoleView = 302;
        public const long RoleDelete = 303;
        public const long RoleList = 304;
        public const long RoleFullAccess = 305;
    }

    public static partial class PermissionGroupIds
    {
        public const long User = 200;
        public const long Role = 300;
    }
}
