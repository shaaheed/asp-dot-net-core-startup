using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Taxes
{
    public class DeleteTaxCommand : CommandBase<long>
    {
        public Guid Id { get; set; }
    }
}
