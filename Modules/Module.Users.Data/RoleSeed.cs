using Core.Interfaces.Data;
using Module.Users.Entities;
using System.Collections.Generic;

namespace Module.Users.Data
{
    public class RoleSeed : ISeed<Role>
    {
        public int Order => 0;
        public IEnumerable<Role> GetSeeds()
        {
            return new List<Role>
            {
                new Role {
                    Id = 1,
                    Name = "Administrator",
                    Code = "administrator"
                },
                new Role {
                    Id = 2,
                    Name = "Customer",
                    Code = "customer"
                },
                new Role {
                    Id = 3,
                    Name = "Vendor",
                    Code = "vendor"
                },
            };
        }
    }
}
