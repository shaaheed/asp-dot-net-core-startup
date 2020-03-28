using Core.Infrastructure.Queries;

namespace Module.Sales.Domain.Bills
{
    public class GetBillQuery : IQuery<BillDetailsDto>
    {
        public long Id { get; set; }
    }
}
