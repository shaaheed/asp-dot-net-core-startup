using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain
{
    public class UnitListItemDto : GuidIdNameDto
    {
        public GuidIdNameDto Type { get; set; }
        public bool IsBaseUnit { get; set; }
        public float ConversionRate { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Unit, UnitListItemDto>> Selector()
        {
            return x => new UnitListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Type = new GuidIdNameDto { Id = x.TypeId, Name = x.Type.Name },
                IsBaseUnit = x.IsBaseUnit,
                ConversionRate = x.ConvertionRate,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
