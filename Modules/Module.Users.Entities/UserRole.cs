using Microsoft.AspNetCore.Identity;
using Msi.Data.Entity;

namespace Module.Users.Entities
{
    public class UserRole : IdentityUserRole<long>, IEntity
    {
        public long Id { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}