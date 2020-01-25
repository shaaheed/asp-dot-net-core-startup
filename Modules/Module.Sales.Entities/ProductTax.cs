using Core.Interfaces.Entities;

namespace Module.Sales.Entities
{
    public class ProductTax : BaseEntity
    {
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public long TaxId { get; set; }
        public virtual Tax Tax { get; set; }
    }
}
