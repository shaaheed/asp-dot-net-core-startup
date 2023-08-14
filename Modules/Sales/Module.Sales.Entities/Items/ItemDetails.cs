using Module.Systems.Entities;
using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    [IgnoredEntity]
    public class ItemDetails : OrganizationEntity
    {
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        public string Description { get; set; }

        public bool IsPriceTaxInclusive { get; set; }

        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        public Guid? TaxId { get; set; }
        public virtual TaxCode Tax { get; set; }

        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }

        // Default location for sale/purchase
        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
