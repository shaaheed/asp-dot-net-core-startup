using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using System.Collections.Generic;

namespace Module.Sales.Domain.Vendors
{
    public class GetVendorsQuery : IQuery<IEnumerable<VendorDto>>
    {
    }
}
