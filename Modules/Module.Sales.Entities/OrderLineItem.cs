using Core.Interfaces.Entities;

namespace Module.Sales.Entities
{
    public class OrderLineItem : BaseEntity
    {
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
        public long LineItemId { get; set; }
        public LineItem LineItem { get; set; }

    }
}
