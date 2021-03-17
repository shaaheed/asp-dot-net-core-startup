using Module.Sales.Entities;
using Module.Core.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Units
{
    public class UnitListItemDto : GuidCodeNameDto
    {
        public string Symbol { get; set; }
        public GuidIdNameDto Type { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Unit, UnitListItemDto>> Selector()
        {
            return x => new UnitListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Symbol = x.Symbol,
                Type = new GuidIdNameDto { Id = x.TypeId, Name = x.Type.Name },
                CreatedAt = x.CreatedAt
            };
        }
    }
}
