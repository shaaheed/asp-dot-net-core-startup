using Module.Systems.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Systems.Domain
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
