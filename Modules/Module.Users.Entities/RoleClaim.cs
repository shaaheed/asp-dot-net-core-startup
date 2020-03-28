using Core.Interfaces.Entities;
using Microsoft.AspNetCore.Identity;

namespace Module.Users.Entities
{
    public class RoleClaim : IdentityRoleClaim<long>, IEntity
    {
        
    }
}