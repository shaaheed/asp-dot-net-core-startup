using Module.Systems.Entities;
using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class ItemPurchaseDetailsCurrency : OrganizationEntity
    {
        public Guid ItemPurchaseDetailsId { get; set; }
        public virtual ItemPurchaseDetails ItemPurchaseDetails { get; set; }

        public Guid CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
