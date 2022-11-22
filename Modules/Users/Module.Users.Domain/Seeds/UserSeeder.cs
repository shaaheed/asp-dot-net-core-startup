using Microsoft.AspNetCore.Identity;
using Module.Accounts.Entities;
using Msi.Data.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Accounts.Domain
{
    public class UserSeeder : AbstractSeeder<User>
    {
        public override IEnumerable<User> GetSeeds()
        {
            var users = new List<User>();
            var user1 = new User
            {
                Id = new Guid("82ca2295-adf1-4e1d-b8b2-9bd9e65efddf"),
                Email = "admin@gmail.com",
                EmailConfirmed = false,
                LockoutEnabled = true,
                UserName = "admin@gmail.com",
            };
            user1.PasswordHash = new PasswordHasher<User>().HashPassword(user1, "123456");
            users.Add(user1);
            return users;
        }
    }
}
