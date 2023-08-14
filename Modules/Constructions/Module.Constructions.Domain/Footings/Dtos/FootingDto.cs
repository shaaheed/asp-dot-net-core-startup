using Module.Constructions.Entities;
using Module.Systems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Constructions.Domain
{
    public class FootingDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Nos { get; set; }
        public FootingType Type { get; set; }
        public GuidIdNameDto UnitType { get; set; }
        public float Volumne { get; set; }
        public GuidIdNameDto VolumneUnit { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public IEnumerable<FootingValueDto> Values { get; set; }

        public static Expression<Func<Footing, FootingDto>> Selector()
        {
            return x => new FootingDto
            {
                Id = x.Id,
                Name = x.Name,
                Nos = x.Nos,
                Values = x.Values.Select(y => new FootingValueDto { Id = y.Id, Type = y.Type, Value = y.Value.Value, Unit = new GuidIdNameDto { Id = y.Value.UnitId, Name = y.Value.Unit.Name } }),
                Volumne = x.Volumne,
                VolumneUnit = new GuidIdNameDto { Id = x.VolumneUnitId, Name = x.VolumneUnit.Name },
                CreatedAt = x.CreatedAt
            };
        }
    }
}
