using Core.Infrastructure.Commands;

namespace Module.Sales.Domain.Products
{
    public class DeleteProductCommand : CommandBase<long>
    {
        public long Id { get; set; }
    }
}
