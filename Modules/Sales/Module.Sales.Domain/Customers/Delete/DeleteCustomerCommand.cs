using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Customers
{
    public class DeleteCustomerCommand : ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
