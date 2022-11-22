using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class DeleteUnitTypeCommandHandler : DeleteCommandHandler<UnitType, DeleteUnitTypeCommand>
    {
        public DeleteUnitTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
