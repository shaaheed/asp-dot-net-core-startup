using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using System.Collections.Generic;

namespace Module.Sales.Domain.Customers
{
    public class GetCustomersQuery : IQuery<IEnumerable<CustomerDto>>
    {
    }
}
