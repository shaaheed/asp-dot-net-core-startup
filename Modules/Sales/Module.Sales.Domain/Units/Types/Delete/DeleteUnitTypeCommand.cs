using Msi.Mediator.Abstractions;

namespace Module.Sales.Domain.Units
{
    public class DeleteUnitTypeCommand : IDeleteCommand<bool>
    {
        public Guid Id { get; set; }
    }
}
