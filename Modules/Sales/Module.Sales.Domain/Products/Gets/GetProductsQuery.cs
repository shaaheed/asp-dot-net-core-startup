using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Module.Sales.Domain.Products
{
    public class GetProductsQuery : IQuery<IEnumerable<ProductDto>>
    {
    }
}
