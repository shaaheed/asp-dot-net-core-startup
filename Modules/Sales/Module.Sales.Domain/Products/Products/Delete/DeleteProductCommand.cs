using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Products
{
    public class DeleteProductCommand : IDeleteCommand<ProductCreatedEvent, bool>
    {
        public Guid Id { get; set; }
    }
}
