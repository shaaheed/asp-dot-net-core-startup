using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Taxes
{
    public class DeleteTaxCommand : IDeleteCommand<bool>
    {
        public Guid Id { get; set; }
    }
}
