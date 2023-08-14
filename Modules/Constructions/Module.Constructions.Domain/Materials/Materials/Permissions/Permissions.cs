using System;

namespace Module.Constructions.Domain
{
    public static partial class PermissionCodes
    {
        public const string MaterialCreate = "materials.create";
        public const string MaterialUpdate = "materials.update";
        public const string MaterialView = "materials.view";
        public const string MaterialDelete = "materials.delete";
        public const string MaterialList = "materials.list";
        public const string MaterialFullAccess = "materials.full.access";
    }

    public static partial class PermissionIds
    {
        public static Guid MaterialCreate = new Guid("5cfafc24-4757-437d-ba40-95b37b152053");
        public static Guid MaterialUpdate = new Guid("cff75df5-dc59-490d-9463-1ec90cda950c");
        public static Guid MaterialView = new Guid("f4dad504-db47-40f1-adb1-a32f111bdf9c");
        public static Guid MaterialDelete = new Guid("4a09ae46-d244-4dbd-8b54-a1ceb09cef3d");
        public static Guid MaterialList = new Guid("a4fdffb5-e276-48f4-81c5-34063c83a6d7");
        public static Guid MaterialFullAccess = new Guid("6191272f-8db5-4105-9069-4bc336de348b");
    }

    public static partial class PermissionGroupIds
    {
        public static Guid Material = new Guid("d208556c-8ef2-4f6d-bf9f-5da90326a37b");
    }
}
