using Module.Sales.Entities;
using System;

namespace Module.Sales.Domain.Items
{
    public class ItemDetailsRequestDto
    {
        public Guid? Id { get; set; }
        public Guid ItemId { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public bool IsPriceTaxInclusive { get; set; }
        public Guid? UnitId { get; set; }
        public Guid? TaxId { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? CurrencyId { get; set; }

        public virtual ItemDetails Map(ItemDetails entity = null)
        {
            entity = entity ?? new ItemDetails();
            entity.ItemId = ItemId;
            entity.Description = Description;
            entity.Price = Price;
            entity.IsPriceTaxInclusive = IsPriceTaxInclusive;
            entity.UnitId = UnitId;
            entity.TaxId = TaxId;
            entity.AccountId = AccountId;
            entity.CurrencyId = CurrencyId;
            return entity;
        }
    }
}
