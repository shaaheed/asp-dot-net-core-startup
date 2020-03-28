using Core.Interfaces.Entities;
using Microsoft.AspNetCore.Identity;

namespace Module.Users.Entities
{
    public class UserRole : IdentityUserRole<long>, IEntity
    {
        public long Id { get; set; }
    }
}