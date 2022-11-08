using Module.Accounts.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Accounts.Domain
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Role, RoleDto>> Selector()
        {
            return x => new RoleDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
