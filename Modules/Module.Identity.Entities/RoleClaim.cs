using Core.Interfaces.Entities;
using Microsoft.AspNetCore.Identity;

namespace Module.Identity.Entities
{
    public class RoleClaim : IdentityRoleClaim<long>, IEntity
    {
        
    }
}