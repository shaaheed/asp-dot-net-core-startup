using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Products
{
    public class GetCategoryQuery : IQuery<CategoryDto>
    {
        public Guid Id { get; set; }
    }
}
