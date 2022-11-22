using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class DeleteUnitCommandHandler : DeleteCommandHandler<Unit, DeleteUnitCommand>
    {
        public DeleteUnitCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
