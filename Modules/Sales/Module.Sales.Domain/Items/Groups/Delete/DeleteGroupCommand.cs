using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Items
{
    public class DeleteGroupCommand : IDeleteCommand<bool>
    {
        public Guid Id { get; set; }
    }
}
