namespace Module.Users.Domain
{
    public static partial class PermissionCodes
    {
        public const string UserCreate = "users.create";
        public const string UserUpdate = "users.update";
        public const string UserView = "users.view";
        public const string UserDelete = "users.delete";
        public const string UserList = "users.list";
        public const string UserFullAccess = "users.full.access";
    }

    public static partial class PermissionIds
    {
        public const long UserCreate = 200;
        public const long UserUpdate = 201;
        public const long UserView = 202;
        public const long UserDelete = 203;
        public const long UserList = 204;
        public const long UserFullAccess = 205;
    }

    public static partial class PermissionGroupIds
    {
        public const long User = 200;
    }
}
