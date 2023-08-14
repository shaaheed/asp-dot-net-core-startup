using Module.Systems.Entities;
using Msi.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Constructions.Entities
{
    [Table(nameof(FootingMaterialCost), Schema = SchemaConstants.Constructions)]
    public class FootingMaterialCost : RootOrganizationEntity
    {
        public string Name { get; set; }

        public Guid FootingId { get; set; }
        public virtual Footing Footing { get; set; }

        public Guid? MaterialId { get; set; }
        public virtual Material Material { get; set; }

        public float Value { get; set; }
        public Guid ValueUnitId { get; set; }
        public virtual Unit ValueUnit { get; set; }

        public float QtyConversionRate { get; set; }

        public float Quantity { get; set; }
        public float UnitPrice { get; set; }

        public double TotalPrice { get; set; }
    }
}
