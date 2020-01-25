using Core.Infrastructure.Queries;

namespace Module.Sales.Domain.Customers
{
    public class GetCustomerQuery : IQuery<CustomerDto>
    {
        public long Id { get; set; }
    }
}
