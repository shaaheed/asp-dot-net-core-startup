using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Bills
{
    public class GetBillQuery : IQuery<BillDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
