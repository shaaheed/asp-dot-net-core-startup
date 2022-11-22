using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class VariantListItemDto : GuidCodeNameDto
    {
        public DateTimeOffset? CreatedAt { get; set; }

        public GuidIdNameDto BaseUnit { get; set; }

        public static Expression<Func<Variant, VariantListItemDto>> Selector()
        {
            return x => new VariantListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
