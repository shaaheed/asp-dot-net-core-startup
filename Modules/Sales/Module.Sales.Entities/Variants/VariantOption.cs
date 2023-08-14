using Module.Systems.Entities;
using System;

namespace Module.Sales.Entities
{
    public class VariantOption : OrganizationNameEntity
    {
        public Guid VariantId { get; set; }
        public virtual Variant Variant { get; set; }
    }
}
