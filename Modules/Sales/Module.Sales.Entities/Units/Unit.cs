using Module.Systems.Entities;
using System;

namespace Module.Sales.Entities
{
    // Unit of Measurement
    public class Unit : CodeNameEntity
    {
        public string Symbol { get; set; }
        public string Description { get; set; }
        public Guid TypeId { get; set; }
        public UnitType Type { get; set; }
    }
}
