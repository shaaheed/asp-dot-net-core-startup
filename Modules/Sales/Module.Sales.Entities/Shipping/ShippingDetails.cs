using Msi.Data.Entity;

namespace Module.Sales.Entities
{
    public class ShippingDetails : BaseEntity, IOrganizationEntity
    {
        public float Weight { get; set; }
        public WeightUnit? Unit { get; set; }

        public Guid? OrganizationId { get; set; }
    }
}
