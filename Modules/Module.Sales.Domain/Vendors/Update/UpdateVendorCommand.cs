using Core.Infrastructure.Commands;

namespace Module.Sales.Domain.Vendors
{
    public class UpdateVendorCommand : ICommand<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Contact { get; set; }
    }
}
