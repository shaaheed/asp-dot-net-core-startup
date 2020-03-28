using Core.Interfaces.Entities;
using Microsoft.AspNetCore.Identity;

namespace Module.Users.Entities
{
    public class UserLogin : IdentityUserLogin<long>, IEntity
    {
        public long Id { get; set; }
    }
}