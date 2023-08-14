using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Constructions.Entities;
using System;

namespace Module.Constructions.Domain
{
    public class CreateMaterialCommandHandler : CreateCommandHandler<Material, CreateMaterialCommand>
    {

        public CreateMaterialCommandHandler(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }

        public override Task<Guid?> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            return base.Handle(request.Map(), cancellationToken);
        }
    }
}
