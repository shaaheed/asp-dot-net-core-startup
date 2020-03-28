using Core.Infrastructure.Commands;

namespace Module.Sales.Domain.Vendors
{
    public class CreateVendorCommand : ICommand<long>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Contact { get; set; }
    }
}
