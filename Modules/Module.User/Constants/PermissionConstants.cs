namespace Comment.Application.Constants
{
    public class PermissionConstants
    {

        public class Operations
        {
            public const string READ_LIST = "read.list";
            public const string READ_DETAILS = "read.details";
            public const string CREATE = "create";
            public const string EDIT = "edit";
            public const string DELETE = "delete";
            public const string BULK_DELETE = "bulk.delete";
            public const string SCAN = "scan";
            public const string SEED = "seed";
            public const string SYNC = "sync";
        }

        public static class Permission
        {
            public const string COMMENTS = "comments";
            public const string PERMISSIONS = "permissions";
            public const string USERS = "users";
            public const string TYPES = "types";
            public const string COMMANDS = "commands";
            public const string RESOURCES = "resources";
            public const string RESOURCES_GROUPS = "resources.groups";
            public const string USERS_GROUPS = "users.groups";
        }

    }
}
