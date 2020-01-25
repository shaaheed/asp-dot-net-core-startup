using Core.Interfaces.Entities;
using Microsoft.AspNetCore.Identity;

namespace Module.Identity.Entities
{
    public class UserClaim : IdentityUserClaim<long>, IEntity
    {
    }
}
