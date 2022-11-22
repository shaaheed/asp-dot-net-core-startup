using System;

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
        public static Guid UserCreate = new Guid("d2115efd-58ec-4af8-845b-c8fc446d2e48");
        public static Guid UserUpdate = new Guid("ea369819-1459-48b9-aee7-1b87a11be553");
        public static Guid UserView = new Guid("9ed03825-3865-49ab-ba20-c86890c1ba81");
        public static Guid UserDelete = new Guid("2338c64a-19d1-4f9a-bbd4-c2e47088feca");
        public static Guid UserList = new Guid("338e29d9-6767-4c8e-93ec-a55e4b478d76");
        public static Guid UserFullAccess = new Guid("445f169e-4a82-449f-85a7-ed43b9c055f1");

        public static Guid RoleCreate = new Guid("56f95415-99e2-4905-a3a6-dd1e50a772e2");
        public static Guid RoleUpdate = new Guid("0f480ddc-80cb-47e7-a572-4c3ef3926ae1");
        public static Guid RoleView = new Guid("cfa814c3-57e8-4519-8d44-bdf6aa2a9553");
        public static Guid RoleDelete = new Guid("17d183de-eb36-415a-88a3-d8fc934acb1e");
        public static Guid RoleList = new Guid("d4bc33fd-3666-4dc6-a281-5453ce7e41c3");
        public static Guid RoleFullAccess = new Guid("ed3c9a76-4a67-47ab-89d6-490ed3d95c6b");
    }

    public static partial class PermissionGroupIds
    {
        public static Guid User = new Guid("69e14be5-7232-41eb-a945-ec12941286d5");
        public static Guid Role = new Guid("9218f4c8-b009-4d7b-9af8-1da4da891ef5");
    }
}
