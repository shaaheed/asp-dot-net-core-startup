using Core.Interfaces.Entities;

namespace Module.Sales.Entities
{
    public class LineItemTax : BaseEntity
    {
        public long LineItemId { get; set; }
        public virtual LineItem LineItem { get; set; }

        public long TaxId { get; set; }
        public virtual Tax Tax { get; set; }
    }
}
