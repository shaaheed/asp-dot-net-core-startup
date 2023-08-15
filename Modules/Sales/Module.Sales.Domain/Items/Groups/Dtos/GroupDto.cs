using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Items
{
    public class GroupDto : GuidCodeNameDto
    {
        public string Description { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Group, GroupDto>> Selector()
        {
            return x => new GroupDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
