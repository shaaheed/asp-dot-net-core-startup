using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Module.Sales.Domain.Vendors
{
    public class GetVendorsQuery : IQuery<IEnumerable<VendorDto>>
    {
    }
}
