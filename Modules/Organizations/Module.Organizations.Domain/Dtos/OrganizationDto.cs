using Module.Organizations.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Organizations.Domain
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Organization, OrganizationDto>> Selector()
        {
            return x => new OrganizationDto
            {
                Id = x.Id,
                Name = x.Name
            };
        }
    }
}
