using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Units
{
    public class UnitListItemDto : GuidCodeNameDto
    {
        public string Symbol { get; set; }
        public GuidIdNameDto Type { get; set; }
        public GuidCodeNameDto BaseUnit { get; set; }
        public float Factor { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Unit, UnitListItemDto>> Selector()
        {
            return x => new UnitListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Symbol = x.Name,
                Type = new GuidIdNameDto { Id = x.TypeId, Name = x.Type.Name },
                BaseUnit = x.BaseUnitId != null ? new GuidCodeNameDto
                {
                    Id = (Guid)x.BaseUnitId,
                    Code = x.BaseUnit.Name,
                    Name = x.BaseUnit.Name
                } : null,
                Factor = x.ConvertionRate,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
