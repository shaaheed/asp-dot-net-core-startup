using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Entities;

namespace Module.Sales.Domain
{
    public class UpdateVariantOptionCommandHandler : ICommandHandler<UpdateVariantOptionCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateVariantOptionCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateVariantOptionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GetRepository<VariantOption>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if(entity != null)
            {
                request.Map(entity);
            }
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
