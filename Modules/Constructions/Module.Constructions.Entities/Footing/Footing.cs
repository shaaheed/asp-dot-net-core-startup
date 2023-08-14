using Module.Systems.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Constructions.Entities
{
    [Table(nameof(Footing), Schema = SchemaConstants.Constructions)]
    public class Footing : OrganizationNameEntity
    {

        public Footing()
        {
            MaterialCosts = new HashSet<FootingMaterialCost>();
            ConcreteRatios = new HashSet<FootingConcreteRatio>();
        }

        // No's of footing
        public float Nos { get; set; }

        public Guid UnitTypeId { get; set; }
        public virtual UnitType UnitType { get; set; }

        public float Length { get; set; }
        public Guid LengthUnitId { get; set; }
        public virtual Unit LengthUnit { get; set; }

        public float Width { get; set; }
        public Guid WidthUnitId { get; set; }
        public virtual Unit WidthUnit { get; set; }

        public float Thickness { get; set; }
        public Guid ThicknessUnitId { get; set; }
        public virtual Unit ThicknessUnit { get; set; }

        public float ClearCover { get; set; }
        public Guid ClearCoverUnitId { get; set; }
        public virtual Unit ClearCoverUnit { get; set; }

        public float BarLength { get; set; }
        public Guid BarLengthUnitId { get; set; }
        public virtual Unit BarLengthUnit { get; set; }

        public float BarWidth { get; set; }
        public Guid BarWidthUnitId { get; set; }
        public virtual Unit BarWidthUnit { get; set; }

        public float MatamLength { get; set; }
        public Guid MatamLengthUnitId { get; set; }
        public virtual Unit MatamLengthUnit { get; set; }

        public float DryVolumne { get; set; }
        public Guid DryVolumneUnitId { get; set; }
        public virtual Unit DryVolumneUnit { get; set; }

        public float Soling { get; set; }
        public Guid SolingUnitId { get; set; }
        public virtual Unit SolingUnit { get; set; }

        public float TotalConcreteRatio { get; set; }

        public virtual ICollection<FootingMaterialCost> MaterialCosts { get; set; }
        public virtual ICollection<FootingConcreteRatio> ConcreteRatios { get; set; }


    }
}
