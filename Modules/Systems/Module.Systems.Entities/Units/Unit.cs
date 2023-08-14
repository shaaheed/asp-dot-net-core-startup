using Msi.Data.Entity;
using System;

namespace Module.Systems.Entities
{
    // Unit of Measurement
    public class Unit : OrganizationEntity
    {
        public string Name { get; set; }
        public string PluralName { get; set; }

        public string Description { get; set; }

        public Guid TypeId { get; set; }
        public UnitType Type { get; set; }

        public bool IsBaseUnit { get; set; }

        // Convertion Rate (Base)
        public float ConvertionRate { get; set; }
    }
}
