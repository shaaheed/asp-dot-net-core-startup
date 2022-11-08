using Module.Permissions.Entities;
using static Module.Accounts.Domain.PermissionIds;
using static Module.Accounts.Domain.PermissionGroupIds;
using Module.Permissions.Shared;
using Msi.Data.Entity;

namespace Module.Accounts.Domain
{
    public class UserPermissionSeeds : ISeed<Permission>
    {
        public int Order => 0;
        public IEnumerable<Permission> GetSeeds()
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
