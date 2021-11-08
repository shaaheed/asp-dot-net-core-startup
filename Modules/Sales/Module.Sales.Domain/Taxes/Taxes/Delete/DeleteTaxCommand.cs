using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Taxes
{
    public class DeleteTaxCommand : IDeleteCommand<Tax, bool>
    {
        public Guid Id { get; set; }
    }
}
