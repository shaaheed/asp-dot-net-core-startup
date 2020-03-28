namespace Module.Users.Common
{
    public static class Permissions
    {
        public const string UserCreate = "users.create";
        public const string UserUpdate = "users.update";
        public const string UserView = "users.view";
        public const string UserDelete = "users.delete";
        public const string UserList = "users.list";
        public const string UserManage = "users.manage";

        public static class Group
        {
            public const string User = "User";
        }
    }
}
