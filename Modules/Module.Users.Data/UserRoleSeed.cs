using Core.Interfaces.Data;
using Module.Users.Entities;
using System.Collections.Generic;

namespace Module.Users.Data
{
    public class UserRoleSeed : ISeed<UserRole>
    {
        public int Order => 1;
        public IEnumerable<UserRole> GetSeeds()
        {
            return new List<UserRole>
            {
                new UserRole {
                    Id = -1,
                    UserId = 1,
                    RoleId = 1
                }
            };
        }
    }
}
