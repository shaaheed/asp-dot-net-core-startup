using Module.Sales.Entities;
using Module.Core.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Products
{
    public class CategoryListItemDto : GuidCodeNameDto
    {
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Category, CategoryListItemDto>> Selector()
        {
            return x => new CategoryListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
