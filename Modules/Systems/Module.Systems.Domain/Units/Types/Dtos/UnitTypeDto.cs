using Module.Systems.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Module.Systems.Domain
{
    public class UnitTypeDto : UnitTypeListItemDto
    {
        public ICollection<UnitDto> Units { get; set; }
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
