using Core.Infrastructure.Queries;

namespace Module.Sales.Domain.Products
{
    public class GetProductQuery : IQuery<ProductDto>
    {
        public long Id { get; set; }
    }
}
