using System;
using System.Collections.Generic;

namespace Module.Sales.Entities
{
    public class Invoice : BaseInvoice
    {
        public string OrderNumber { get; set; }

        // If invoice amount is $110 and customer pays $120 as Cash then $10 must be return amount.
        public decimal? ReturnAmount { get; set; }

        public Guid? CustomerId { get; set; }
        public virtual Contact Customer { get; set; }

        public Guid? SalesPersonId { get; set; }
        public virtual Contact SalesPerson { get; set; }

        public string AdjustmentText { get; set; }
        public decimal AdjustmentAmount { get; set; }

        public Guid? FromQuoteId { get; set; }
        public virtual Quote FromQuote { get; set; }

        public virtual ICollection<InvoicePayment> InvoicePayments { get; set; }
    }
}
