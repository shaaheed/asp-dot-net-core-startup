using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Module.Sales.Domain.Customers
{
    public class GetCustomersQuery : IQuery<IEnumerable<CustomerDto>>
    {
    }
}
