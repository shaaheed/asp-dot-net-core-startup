using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using Module.Systems.Entities;

namespace Module.Systems.Domain
{
    public class DeleteUnitTypeCommandHandler : DeleteCommandHandler<UnitType, DeleteUnitTypeCommand>
    {
        public DeleteUnitTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
