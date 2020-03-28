using Core.Interfaces.Data;
using Microsoft.AspNetCore.Identity;
using Module.Users.Entities;
using System;
using System.Collections.Generic;

namespace Module.Users.Data
{
    public class UserSeed : ISeed<User>
    {
        public int Order => 0;
        public IEnumerable<User> GetSeeds()
        {
            var users = new List<User>();
            var user1 = new User
            {
                Id = 1,
                Email = "admin@gmail.com",
                EmailConfirmed = false,
                LockoutEnabled = true,
                NormalizedEmail = "ADMIN@GMAIL.COM",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                UserName = "admin@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user1.PasswordHash = new PasswordHasher<User>().HashPassword(user1, "123456");

            users.Add(user1);
            return users;
        }
    }
}
