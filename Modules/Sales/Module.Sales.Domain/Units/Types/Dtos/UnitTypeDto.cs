using Module.Sales.Entities;
using Module.Core.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Products
{
    public class UnitTypeDto : GuidCodeNameDto
    {
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<UnitType, UnitTypeDto>> Selector()
        {
            return x => new UnitTypeDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
