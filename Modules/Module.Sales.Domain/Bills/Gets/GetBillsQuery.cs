using Core.Infrastructure.Queries;
using System.Collections.Generic;

namespace Module.Sales.Domain.Bills
{
    public class GetBillsQuery : IQuery<IEnumerable<BillDto>>
    {
    }
}
