using Core.Infrastructure.Commands;

namespace Module.Sales.Domain.Bills
{
    public class DeleteBillCommand : ICommand<long>
    {
        public long Id { get; set; }
    }
}
