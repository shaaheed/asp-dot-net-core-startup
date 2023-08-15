using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Items
{
    public class DeleteCategoryCommand : IDeleteCommand<bool>
    {
        public Guid Id { get; set; }
    }
}
