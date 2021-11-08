using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Products
{
    public class DeleteCategoryCommand : IDeleteCommand<Category, bool>
    {
        public Guid Id { get; set; }
    }
}
