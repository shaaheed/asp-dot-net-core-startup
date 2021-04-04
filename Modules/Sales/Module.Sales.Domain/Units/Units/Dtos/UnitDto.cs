using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Units
{
    public class UnitDto : GuidCodeNameDto
    {
        public string Symbol { get; set; }
        public string Description { get; set; }
        public GuidIdNameDto Type { get; set; }
        public GuidCodeNameDto BaseUnit { get; set; }
        public float Factor { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Unit, UnitDto>> Selector()
        {
            return x => new UnitDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Description = x.Description,
                Symbol = x.Symbol,
                Type = new GuidIdNameDto { Id = x.TypeId, Name = x.Type.Name },
                BaseUnit = x.BaseUnitId != null ? new GuidCodeNameDto
                {
                    Id = (Guid)x.BaseUnitId,
                    Code = x.BaseUnit.Symbol,
                    Name = x.BaseUnit.Name
                } : null,
                Factor = x.Factor,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
