using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Items
{
    public class CategoryDto : GuidCodeNameDto
    {
        public string Description { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Category, CategoryDto>> Selector()
        {
            return x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                // TODO Code = x.Code,
                Description = x.Description,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
