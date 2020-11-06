using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Vendors
{
    public class GetVendorQuery : IQuery<VendorDto>
    {
        public Guid Id { get; set; }
    }
}
