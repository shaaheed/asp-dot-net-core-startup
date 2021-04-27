using System;

namespace Module.Sales.Domain
{
    public class BillLineItemRequestDto : BaseInvoiceLineItemRequestDto
    {
        public Guid? BillId { get; set; }
    }
}
