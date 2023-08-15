using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Items
{
    public class DeleteItemCommand : IDeleteCommand<bool>
    {
        public Guid Id { get; set; }
    }
}
