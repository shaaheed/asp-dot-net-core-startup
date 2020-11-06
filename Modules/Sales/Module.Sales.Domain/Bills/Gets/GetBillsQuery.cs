using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Module.Sales.Domain.Bills
{
    public class GetBillsQuery : IQuery<IEnumerable<BillDto>>
    {
    }
}
