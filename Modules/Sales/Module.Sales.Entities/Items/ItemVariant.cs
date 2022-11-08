using Msi.Data.Entity;

namespace Module.Sales.Entities
{
    public class ItemVariant : OrganizationEntity
    {
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        public Guid VariantId { get; set; }
        public virtual Variant Variant { get; set; }

        public Guid? SaleDetailsId { get; set; }
        public virtual SaleDetails SaleDetails { get; set; }

        public Guid? PurchaseDetailsId { get; set; }
        public virtual PurchaseDetails PurchaseDetails { get; set; }
    }
}
