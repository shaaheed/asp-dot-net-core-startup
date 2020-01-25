using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Msi.Extensions.Persistence.EntityFrameworkCore;
using Module.Identity.Entities;

namespace Module.Identity.Persistence.EntityFramework
{
    public class EntityBuilder : IModelBuilder
    {

        public string DefaultSchema { get; } = "Identity";

        public void Build(ModelBuilder modelBuilder)
        {

            //modelBuilder.HasDefaultSchema(DefaultSchema);
            modelBuilder.Entity<User>()
                .HasData(GetUsers());
        }

        private List<User> GetUsers()
        {
            List<User> users = new List<User>();
            User user1 = new User
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
