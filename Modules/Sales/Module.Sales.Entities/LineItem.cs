using Msi.Data.Entity;
using System;
using System.Collections.Generic;

namespace Module.Sales.Entities
{
    public class LineItem : BaseEntity
    {

        public LineItem(ItemTransactionType type)
        {
            Type = type;
        }

        public LineItem()
        {
            LineItemTaxes = new HashSet<LineItemTax>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Note { get; set; }


        // could be InvoiceId, BillId, AdjustmentId etc.
        public Guid? ReferenceId { get; set; }
        public ItemTransactionType Type { get; set; }

        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }
        public DiscountType? DiscountType { get; set; }

        public Guid? UnitId { get; set; }
        public Unit Unit { get; set; }

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

        public float Quantity { get; set; }

        public virtual ICollection<LineItemTax> LineItemTaxes { get; set; }
    }
}
