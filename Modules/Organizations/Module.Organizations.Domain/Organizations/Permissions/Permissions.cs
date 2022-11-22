using System;

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
        public static Guid OrganizationCreate = new Guid("7e611bec-8a27-4fae-842c-6312b3af689e");
        public static Guid OrganizationUpdate = new Guid("7e047dbb-5869-40ad-9a03-a6e8425e2fad");
        public static Guid OrganizationView = new Guid("1fff988b-489d-42b0-9679-db99c59ff77e");
        public static Guid OrganizationDelete = new Guid("ad24212a-0af2-4d40-86e9-824b66d60e2e");
        public static Guid OrganizationList = new Guid("29398411-1b1b-4f31-8c9b-7071947f7e31");
        public static Guid OrganizationFullAccess = new Guid("022c420b-9ffe-4798-ab56-a5c8b4467515");
    }

    public static partial class PermissionGroupIds
    {
        public static Guid Organization = new Guid("59f427c7-753d-4aeb-8bc6-04bf70443fbb");
    }
}
