using Msi.Data.Entity;
using System;

namespace Module.Accounts.Entities
{
    public class UserForgotPasswordToken : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public string Token { get; set; }
    }
}
