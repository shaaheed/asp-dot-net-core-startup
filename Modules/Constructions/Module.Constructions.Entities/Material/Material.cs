using Module.Systems.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Constructions.Entities
{
    [Table(nameof(Material), Schema = SchemaConstants.Constructions)]
    public class Material : OrganizationNameEntity
    {
        public string Description { get; set; }
        public Guid UnitTypeId { get; set; }
        public virtual UnitType UnitType { get; set; }
        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        public float? UnitPrice { get; set; }
    }
}
