using Core.Interfaces.Entities;

namespace Module.Sales.Entities
{
    public class InvoiceLineItem : BaseEntity
    {
        public long InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public long LineItemId { get; set; }
        public LineItem LineItem { get; set; }

    }
}
