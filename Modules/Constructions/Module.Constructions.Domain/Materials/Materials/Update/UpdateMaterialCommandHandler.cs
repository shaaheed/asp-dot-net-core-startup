using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using Module.Constructions.Entities;

namespace Module.Constructions.Domain
{
    public class UpdateMaterialCommandHandler : ICommandHandler<UpdateMaterialCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateMaterialCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            var org = await _unitOfWork.GetRepository<Material>()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (org == null)
                throw new NotFoundException("Material not found");

            request.Map(org);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
