using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Customers
{
    public class GetCustomerQuery : IQuery<CustomerDto>
    {
        public Guid Id { get; set; }
    }
}
