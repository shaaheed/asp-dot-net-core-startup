using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Products
{
    public class GetProductQuery : IQuery<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
