using Module.Core.Entities;
using System;

namespace Module.Sales.Entities
{
    // Unit of Measurement
    public class Unit : CodeNameEntity
    {
        public string Symbol { get; set; }
        public float Description { get; set; }
        public Guid TypeId { get; set; }
        public UnitType Type { get; set; }
    }
}
