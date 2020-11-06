using Msi.Data.Entity;
using System;

namespace Module.Users.Entities
{
    public class UserToken : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid RefreshTokenId { get; set; }
        public RefreshToken RefreshToken { get; set; }

        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}