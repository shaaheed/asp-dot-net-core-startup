using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class GetBillPaymentQuery : IQuery<BillPaymentDto>
    {
        public Guid BillId { get; set; }
        public Guid Id { get; set; }
    }
}
