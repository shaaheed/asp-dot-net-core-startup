using Module.Systems.Entities;
using Msi.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string Note { get; set; }

        // could be InvoiceId, BillId, AdjustmentId etc.
        public Guid? DocumentId { get; set; }
        public string DocumentName { get; set; }

        // could be CustomerId, SupplierId etc.
        public Guid? ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public LineType LineType { get; set; } = LineType.Transaction;
        public LineTransactionType TransactionType { get; set; }

        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }

        public Guid? ProductId { get; set; }
        public virtual Item Product { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }
        public DiscountType? DiscountType { get; set; }

        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        /// <summary>
        /// Subtotal = UnitPrice * Quantity
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Total = (UnitPrice * Quantity) + TotalTaxAmount
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal Total { get; set; }

        /// <summary>
        /// TotalTaxAmount = Sum(EveryQauntity * AllTaxRate)
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalTaxAmount { get; set; }

        public float Quantity { get; set; }

        public virtual ICollection<LineItemTax> LineItemTaxes { get; set; }
    }
}
