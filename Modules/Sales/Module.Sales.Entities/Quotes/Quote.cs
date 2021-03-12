using Msi.Data.Entity;
using Module.Core.Entities;
using System;
using System.Collections.Generic;

namespace Module.Sales.Entities
{
    public class Quote : BaseEntity
    {
        public Quote()
        {
            QuoteLineItems = new HashSet<QuoteLineItem>();
        }

        public string Code { get; set; }

        public Guid? CustomerId { get; set; }

        /// <summary>
        /// Sum of all line items Subtotal
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Sum of all line items Total
        /// </summary>
        public decimal GrandTotal { get; set; }

        /// <summary>
        /// Sum of all line item TotalTaxAmount
        /// </summary>
        public decimal TotalTaxAmount { get; set; }

        public DateTimeOffset IssueDate { get; set; }
        public string Memo { get; set; }

        public DateTimeOffset ExpiresOn { get; set; }
        public Guid? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public int TotalConvertedInvoice { get; set; }

        public virtual ICollection<QuoteLineItem> QuoteLineItems { get; set; }

        public void Calculate()
        {
            GrandTotal = 0;
            Subtotal = 0;
            foreach (var item in QuoteLineItems)
            {
                GrandTotal += item.LineItem.Total;
                Subtotal += item.LineItem.Subtotal;
            }
        }

    }
}
