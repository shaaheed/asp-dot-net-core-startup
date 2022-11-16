using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Units
{
    public class UnitTypeListItemDto : GuidCodeNameDto
    {
        public DateTimeOffset? CreatedAt { get; set; }

        public GuidIdNameDto BaseUnit { get; set; }

        public static Expression<Func<UnitType, UnitTypeListItemDto>> Selector()
        {
            return x => new UnitTypeListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
