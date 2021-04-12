using Module.Organizations.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Organizations.Domain
{
    public class OrganizationListItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Organization, OrganizationListItemDto>> Selector()
        {
            return x => new OrganizationListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                IsDefault = x.IsDefault,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
