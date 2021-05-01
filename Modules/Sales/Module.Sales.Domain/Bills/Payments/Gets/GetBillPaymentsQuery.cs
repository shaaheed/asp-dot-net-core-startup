using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;
using System;

namespace Module.Sales.Domain
{
    public class GetBillPaymentsQuery : Query<PagedCollection<BillPaymentDto>>
    {
        public Guid BillId { get; set; }
    }
}
