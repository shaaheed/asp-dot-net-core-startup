using Module.Systems.Entities;
using System;

namespace Module.Systems.Domain
{
    public class UnitRequestDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public bool IsBaseUnit { get; set; }
        public float ConversionRate { get; set; }

        public virtual Unit Map(Unit entity = null)
        {
            entity = entity ?? new Unit();
            entity.Name = Name;
            entity.TypeId = TypeId;
            entity.IsBaseUnit = IsBaseUnit;
            entity.ConvertionRate = ConversionRate;
            return entity;
        }
    }
}
