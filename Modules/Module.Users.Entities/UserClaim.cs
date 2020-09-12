using Microsoft.AspNetCore.Identity;
using Msi.Data.Entity;

namespace Module.Users.Entities
{
    public class UserClaim : IdentityUserClaim<long>, IEntity
    {
    }
}
