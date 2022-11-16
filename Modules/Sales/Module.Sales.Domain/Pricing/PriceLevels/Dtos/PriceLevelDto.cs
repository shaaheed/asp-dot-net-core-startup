using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class PriceLevelDto : GuidIdNameDto
    {
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<PriceLevel, PriceLevelDto>> Selector()
        {
            return x => new PriceLevelDto
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
