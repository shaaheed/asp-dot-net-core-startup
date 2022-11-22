using Module.Accounts.Entities;
using Msi.Data.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Accounts.Domain
{
    public class UserRoleSeeder : AbstractSeeder<UserRole>
    {
        public override int Order => 1;

        public override IEnumerable<UserRole> GetSeeds()
        {
            return new List<UserRole>
            {
                new UserRole {
                    Id = new Guid("9218f4c8-b009-4d7b-9af8-1da4da891ef5"),
                    UserId = new Guid("82ca2295-adf1-4e1d-b8b2-9bd9e65efddf"),
                    RoleId = new Guid("a4bc7ff6-4da2-4e5f-8e77-e50ceaa5e74c")
                }
            };
        }
    }
}
