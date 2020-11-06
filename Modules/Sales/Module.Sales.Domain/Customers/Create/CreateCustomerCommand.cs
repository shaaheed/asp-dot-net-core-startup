using Msi.Mediator.Abstractions;

namespace Module.Sales.Domain.Customers
{
    public class CreateCustomerCommand : ICommand<long>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Contact { get; set; }
    }
}
