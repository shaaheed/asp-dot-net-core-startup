using Module.Systems.Entities;
using Msi.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Sales.Entities
{
    [IgnoredEntity]
    public class ItemDetails : OrganizationEntity
    {
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        // Base Price
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Price { get; set; }

        public string Description { get; set; }

        public bool IsPriceTaxInclusive { get; set; }

        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        public Guid? TaxId { get; set; }
        public virtual TaxCode Tax { get; set; }

        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }

        public Guid? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
