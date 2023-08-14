using Module.Systems.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Systems.Domain
{
    public class UnitDto : GuidCodeNameDto
    {
        public string Symbol { get; set; }
        public string Description { get; set; }
        public GuidIdNameDto Type { get; set; }
        public bool IsBaseUnit { get; set; }
        public float ConversionRate { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Unit, UnitDto>> Selector()
        {
            return x => new UnitDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Symbol = x.Name,
                Type = new GuidIdNameDto { Id = x.TypeId, Name = x.Type.Name },
                ConversionRate = x.ConvertionRate,
                IsBaseUnit = x.IsBaseUnit,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
