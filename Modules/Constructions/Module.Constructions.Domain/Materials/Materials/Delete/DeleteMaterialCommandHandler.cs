using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using Module.Constructions.Entities;

namespace Module.Constructions.Domain
{
    public class DeleteMaterialCommandHandler : DeleteCommandHandler<Material, DeleteMaterialCommand>
    {
        public DeleteMaterialCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
