using Core.Interfaces.Entities;

namespace Module.Sales.Entities
{
    public class UnitOfMeasurementType : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
