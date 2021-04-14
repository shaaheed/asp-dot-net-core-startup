using System;
using System.Collections.Generic;
using System.Linq;

namespace Module.Sales.Entities
{
    public class Invoice : BaseInvoice
    {

        public Invoice()
        {
            InvoiceLineItems = new HashSet<InvoiceLineItem>();
        }

        public string OrderNumber { get; set; }

        public Guid? CustomerId { get; set; }
        public virtual Contact Customer { get; set; }

        public Guid? SalesPersonId { get; set; }
        public virtual Contact SalesPerson { get; set; }

        public string AdjustmentText { get; set; }
        public decimal AdjustmentAmount { get; set; }

        public Guid? FromQuoteId { get; set; }
        public virtual Quote FromQuote { get; set; }

        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
        public virtual ICollection<InvoicePayment> InvoicePayments { get; set; }

        public void Calculate()
        {
            Calculate(InvoiceLineItems.Select(x => x.LineItem));
        }
    }
}
