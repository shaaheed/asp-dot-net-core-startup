using Core.Interfaces.Entities;

namespace Module.Sales.Entities
{
    public class QouteLineItem : BaseEntity
    {
        public long QouteId { get; set; }
        public virtual Qoute Qoute { get; set; }
        public long LineItemId { get; set; }
        public LineItem LineItem { get; set; }

    }
}
