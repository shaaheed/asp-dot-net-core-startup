using Msi.Data.Entity;
using System;

namespace Module.Tokens.Entities
{
    public class Token : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid RefreshTokenId { get; set; }
        public RefreshToken RefreshToken { get; set; }

        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}