using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class ItemVariant : OrganizationEntity
    {
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        public Guid VariantId { get; set; }
        public virtual Variant Variant { get; set; }
    }
}
