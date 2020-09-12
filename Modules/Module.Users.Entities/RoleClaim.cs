using Core.Interfaces.Entities;
using Microsoft.AspNetCore.Identity;
using Msi.Data.Entity;

namespace Module.Users.Entities
{
    public class RoleClaim : IdentityRoleClaim<long>, IEntity
    {
        
    }
}