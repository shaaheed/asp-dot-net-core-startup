using Module.Accounts.Entities;
using Msi.Data.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Accounts.Domain
{
    public class RoleSeeder : AbstractSeeder<Role>
    {
        public override IEnumerable<Role> GetSeeds()
        {
            return new List<Role>
            {
                new Role {
                    Id = Guid.Parse("a4bc7ff6-4da2-4e5f-8e77-e50ceaa5e74c"),
                    Name = "Administrator",
                    Code = "administrator"
                }
            };
        }
    }
}
