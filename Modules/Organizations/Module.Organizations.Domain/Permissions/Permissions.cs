namespace Module.Organizations.Domain
{
    public static partial class PermissionCodes
    {
        public const string OrganizationCreate = "organizations.create";
        public const string OrganizationUpdate = "organizations.update";
        public const string OrganizationView = "organizations.view";
        public const string OrganizationDelete = "organizations.delete";
        public const string OrganizationList = "organizations.list";
        public const string OrganizationFullAccess = "organizations.full.access";
    }

    public static partial class PermissionIds
    {
        public const long OrganizationCreate = 300;
        public const long OrganizationUpdate = 301;
        public const long OrganizationView = 302;
        public const long OrganizationDelete = 303;
        public const long OrganizationList = 304;
        public const long OrganizationFullAccess = 305;
    }

    public static partial class PermissionGroupIds
    {
        public const long Organization = 300;
    }
}
