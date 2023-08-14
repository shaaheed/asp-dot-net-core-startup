using Module.Constructions.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Constructions.Domain
{
    public class MaterialDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public GuidIdNameDto UnitType { get; set; }
        public GuidIdNameDto Unit { get; set; }
        public float? UnitPrice { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Material, MaterialDto>> Selector()
        {
            return x => new MaterialDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                UnitType = new GuidIdNameDto { Id = x.UnitTypeId, Name = x.UnitType.Name },
                Unit = x.UnitId != null ? new GuidIdNameDto { Id = x.UnitId.Value, Name = x.Unit.Name } : null,
                UnitPrice = x.UnitPrice,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
