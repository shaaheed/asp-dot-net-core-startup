using Core.Interfaces.Entities;

namespace Module.Sales.Entities
{
    public class UnitOfMeasurement : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        public float Description { get; set; }
        public long TypeId { get; set; }
        public UnitOfMeasurementType Type { get; set; }
    }
}
