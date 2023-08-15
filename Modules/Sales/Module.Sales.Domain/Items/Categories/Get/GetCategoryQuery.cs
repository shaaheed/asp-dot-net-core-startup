using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Items
{
    public class GetCategoryQuery : IQuery<CategoryDto>
    {
        public Guid Id { get; set; }
    }
}
