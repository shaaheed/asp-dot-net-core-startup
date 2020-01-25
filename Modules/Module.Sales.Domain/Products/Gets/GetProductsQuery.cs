using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using System.Collections.Generic;

namespace Module.Sales.Domain.Products
{
    public class GetProductsQuery : IQuery<IEnumerable<ProductDto>>
    {
    }
}
