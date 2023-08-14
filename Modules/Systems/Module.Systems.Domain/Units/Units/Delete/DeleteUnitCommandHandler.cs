using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using Module.Systems.Entities;

namespace Module.Systems.Domain
{
    public class DeleteUnitCommandHandler : DeleteCommandHandler<Unit, DeleteUnitCommand>
    {
        public DeleteUnitCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
