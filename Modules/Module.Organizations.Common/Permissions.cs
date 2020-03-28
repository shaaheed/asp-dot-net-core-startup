namespace Module.Organizations.Common
{
    public static class Permissions
    {
        public const string OrganizationCreate = "organizations.create";
        public const string OrganizationUpdate = "organizations.update";
        public const string OrganizationView = "organizations.view";
        public const string OrganizationDelete = "organizations.delete";
        public const string OrganizationList = "organizations.list";
        public const string OrganizationManage = "organizations.manage";

        public static class Group
        {
            public const string Organization = "Organization";
        }
    }
}
