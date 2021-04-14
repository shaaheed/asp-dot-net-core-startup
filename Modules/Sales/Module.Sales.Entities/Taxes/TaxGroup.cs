using Msi.Data.Entity;

namespace Module.Sales.Entities
{
    public class TaxGroup : OrganizationBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
