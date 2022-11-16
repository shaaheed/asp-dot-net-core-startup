using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Units
{
    public class UnitTypeDto : UnitTypeListItemDto
    {
        public static new Expression<Func<UnitType, UnitTypeDto>> Selector()
        {
            return x => new UnitTypeDto
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
