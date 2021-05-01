using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class GetBillQuery : IQuery<BillDto>
    {
        public Guid Id { get; set; }
    }
}
