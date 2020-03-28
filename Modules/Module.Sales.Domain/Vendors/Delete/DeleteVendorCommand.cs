using Core.Infrastructure.Commands;

namespace Module.Sales.Domain.Vendors
{
    public class DeleteVendorCommand : ICommand<long>
    {
        public long Id { get; set; }
    }
}
