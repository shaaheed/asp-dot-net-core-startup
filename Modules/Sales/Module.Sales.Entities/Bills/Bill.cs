using System;
using System.Collections.Generic;
using System.Linq;

namespace Module.Sales.Entities
{
    public class Bill : BaseInvoice
    {

        public Bill()
        {
            BillLineItems = new HashSet<BillLineItem>();
        }

        public Guid? SupplierId { get; set; }
        public virtual Contact Supplier { get; set; }

        public virtual ICollection<BillLineItem> BillLineItems { get; set; }
        public virtual ICollection<BillPayment> BillPayments { get; set; }

        public void Calculate()
        {
            Calculate(BillLineItems.Select(x => x.LineItem));
        }
    }
}
