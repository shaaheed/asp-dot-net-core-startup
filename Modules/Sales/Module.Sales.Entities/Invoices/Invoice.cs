using System;
using System.Collections.Generic;

namespace Module.Sales.Entities
{
    public class Invoice : InvoiceDocument
    {
        // If invoice amount is $110 and customer pays $120 as Cash then $10 must be return amount.
        public decimal? ReturnAmount { get; set; }

        public Guid? SalesPersonId { get; set; }
        public virtual Contact SalesPerson { get; set; }

        public Guid? QuoteId { get; set; }
        public virtual Quote Quote { get; set; }

        public virtual ICollection<InvoicePayment> InvoicePayments { get; set; }
    }
}
