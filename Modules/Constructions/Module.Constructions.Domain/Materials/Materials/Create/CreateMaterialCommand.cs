using Module.Constructions.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Constructions.Domain
{
    public class CreateMaterialCommand : CreateCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UnitTypeId { get; set; }
        public Guid? UnitId { get; set; }
        public float? UnitPrice { get; set; }

        public virtual Material Map(Material entity = null)
        {
            entity = entity ?? new Material();
            entity.Name = Name;
            entity.Description = Description;
            entity.UnitTypeId = UnitTypeId;
            entity.UnitId = UnitId;
            entity.UnitPrice = UnitPrice;
            return entity;
        }
    }
}
