using Module.Sales.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class VariantDto : VariantListItemDto
    {
        public static new Expression<Func<Variant, VariantDto>> Selector()
        {
            return x => new VariantDto
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
