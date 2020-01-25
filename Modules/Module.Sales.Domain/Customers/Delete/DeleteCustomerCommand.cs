using Core.Infrastructure.Commands;

namespace Module.Sales.Domain.Customers
{
    public class DeleteCustomerCommand : ICommand<long>
    {
        public long Id { get; set; }
    }
}
