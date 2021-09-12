using System;
using System.Collections.Generic;

namespace Module.Sales.Entities
{
    public class Bill : BaseInvoice
    {
        public string OrderNumber { get; set; }

        public string AdjustmentText { get; set; }
        public decimal AdjustmentAmount { get; set; }

        public Guid? SupplierId { get; set; }
        public virtual Contact Supplier { get; set; }

        public virtual ICollection<BillPayment> BillPayments { get; set; }
    }
}
