using Module.Systems.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Constructions.Entities
{
    [Table(nameof(ProjectMaterial), Schema = SchemaConstants.Constructions)]
    public class ProjectMaterial : OrganizationNameEntity
    {
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public Guid UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        public float UnitPrice { get; set; }
    }
}
