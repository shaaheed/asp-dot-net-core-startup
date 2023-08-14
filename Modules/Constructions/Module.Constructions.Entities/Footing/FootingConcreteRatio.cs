using Msi.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Constructions.Entities
{
    [Table(nameof(FootingConcreteRatio), Schema = SchemaConstants.Constructions)]
    public class FootingConcreteRatio : RootOrganizationEntity
    {
        public string Name { get; set; }

        public Guid FootingId { get; set; }
        public virtual Footing Footing { get; set; }

        public Guid? MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public float Ratio { get; set; }
        public bool IsRatioSummable { get; set; } = true;
    }
}
