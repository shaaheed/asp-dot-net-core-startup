using Msi.Data.Entity;
using System;

namespace Module.Tokens.Entities
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
