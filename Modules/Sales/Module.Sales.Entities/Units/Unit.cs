using Module.Systems.Entities;
using System;

namespace Module.Sales.Entities
{
    // Unit of Measurement
    public class Unit : OrganizationCodeNameEntity
    {
        public string Symbol { get; set; }
        public string Description { get; set; }

        public Guid TypeId { get; set; }
        public UnitType Type { get; set; }

        public Guid? BaseUnitId { get; set; }
        public Unit BaseUnit { get; set; }

        // Convertion Factor
        public float Factor { get; set; }
    }
}
