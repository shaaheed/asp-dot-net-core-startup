using Module.Systems.Entities;
using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class ItemSaleDetailsCurrency : OrganizationEntity
    {
        public Guid ItemSaleDetailsId { get; set; }
        public virtual ItemSaleDetails ItemSaleDetails { get; set; }

        public Guid CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
