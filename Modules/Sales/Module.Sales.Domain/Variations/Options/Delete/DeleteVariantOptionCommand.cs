using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class DeleteVariantOptionCommand : DeleteCommand
    {
        public Guid VariantId { get; set; }
    }
}
