using Core.Infrastructure.Queries;

namespace Module.Sales.Domain.Vendors
{
    public class GetVendorQuery : IQuery<VendorDto>
    {
        public long Id { get; set; }
    }
}
