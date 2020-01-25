using Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Module.Sales.Entities
{
    public class LineItem : BaseEntity
    {

        public LineItem()
        {
            LineItemTaxes = new HashSet<LineItemTax>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public long? ProductId { get; set; }
        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }

        /// <summary>
        /// UnitPrice * Quantity
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// (UnitPrice * Quantity) + TotalTaxAmount
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Sum(EveryQauntity * AllTaxRate)
        /// </summary>
        public decimal TotalTaxAmount { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<LineItemTax> LineItemTaxes { get; set; }
    }
}
