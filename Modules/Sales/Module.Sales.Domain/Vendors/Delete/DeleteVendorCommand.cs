using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Vendors
{
    public class DeleteVendorCommand : ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
