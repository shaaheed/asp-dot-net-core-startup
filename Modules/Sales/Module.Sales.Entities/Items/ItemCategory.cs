using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class ItemCategory : OrganizationEntity
    {
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
