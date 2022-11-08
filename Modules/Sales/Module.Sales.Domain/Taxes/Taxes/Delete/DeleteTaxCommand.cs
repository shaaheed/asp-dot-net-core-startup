using Msi.Mediator.Abstractions;

namespace Module.Sales.Domain.Taxes
{
    public class DeleteTaxCommand : IDeleteCommand<bool>
    {
        public Guid Id { get; set; }
    }
}
