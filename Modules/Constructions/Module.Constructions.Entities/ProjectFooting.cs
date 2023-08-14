using Module.Systems.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Constructions.Entities
{
    [Table(nameof(ProjectFooting), Schema = SchemaConstants.Constructions)]
    public class ProjectFooting : OrganizationNameEntity
    {
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public Guid FootingId { get; set; }
        public virtual Footing Footing { get; set; }
    }
}
