using Msi.Data.Entity;

namespace Module.Sales.Entities
{
    public class PriceLevel : NameEntity, IOrganizationEntity
    {
        public Guid? OrganizationId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
