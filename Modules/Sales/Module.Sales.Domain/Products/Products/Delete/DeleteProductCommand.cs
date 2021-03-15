using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Products
{
    public class DeleteProductCommand : CommandBase<long>
    {
        public Guid Id { get; set; }
    }
}
