using Core.Interfaces.Entities;

namespace Module.Sales.Entities
{
    public class BillLineItem : BaseEntity
    {
        public long BillId { get; set; }
        public virtual Bill Bill { get; set; }
        public long LineItemId { get; set; }
        public LineItem LineItem { get; set; }

    }
}
