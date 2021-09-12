using Msi.Data.Entity;

namespace Module.Sales.Entities
{
    public class TaxGroup : OrganizationEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
