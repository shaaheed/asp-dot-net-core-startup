using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class VariantOptionDto : GuidIdNameDto
    {
        public GuidIdNameDto Variant { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<VariantOption, VariantOptionDto>> Selector()
        {
            return x => new VariantOptionDto
            {
                Id = x.Id,
                Name = x.Name,
                Variant = new GuidIdNameDto { Id = x.VariantId, Name = x.Variant.Name },
                CreatedAt = x.CreatedAt
            };
        }
    }
}
