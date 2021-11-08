using System.Collections.Generic;

namespace Module.Sales.Entities
{
    public class Bill : InvoiceDocument
    {
        public virtual ICollection<BillPayment> BillPayments { get; set; }
    }
}
