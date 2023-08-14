using Module.Systems.Entities;
using Msi.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Sales.Entities
{
    public class ItemPrice : BaseEntity, IOrganizationEntity
    {
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        public Guid CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public Guid PricingLevelId { get; set; }
        public virtual PriceLevel PricingLevel { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public Guid? OrganizationId { get; set; }
    }
}
