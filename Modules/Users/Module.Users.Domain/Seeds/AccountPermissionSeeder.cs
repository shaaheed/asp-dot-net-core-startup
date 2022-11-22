using Module.Permissions.Entities;
using static Module.Accounts.Domain.PermissionIds;
using static Module.Accounts.Domain.PermissionGroupIds;
using Module.Permissions.Shared;
using System.Collections.Generic;
using Msi.Data.Abstractions;

namespace Module.Accounts.Domain
{
    public class AccountPermissionSeeder : AbstractSeeder<Permission>
    {
        public override int Order => 1;

        public override IEnumerable<Permission> GetSeeds()
        {
            return new List<Permission>()
                .Create(UserCreate, PermissionCodes.UserCreate, User)
                .Update(UserUpdate, PermissionCodes.UserUpdate, User)
                .List(UserList, PermissionCodes.UserList, User)
                .View(UserView, PermissionCodes.UserView, User)
                .Delete(UserDelete, PermissionCodes.UserDelete, User)
                .FullAccess(UserFullAccess, PermissionCodes.UserFullAccess, User);
        }
    }
}
