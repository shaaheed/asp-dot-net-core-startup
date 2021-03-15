using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Products
{
    public class DeleteCategoryCommand : CommandBase<long>
    {
        public Guid Id { get; set; }
    }
}
