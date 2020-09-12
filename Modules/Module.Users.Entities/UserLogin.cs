using Microsoft.AspNetCore.Identity;
using Msi.Data.Entity;

namespace Module.Users.Entities
{
    public class UserLogin : IdentityUserLogin<long>, IEntity
    {
        public long Id { get; set; }
    }
}