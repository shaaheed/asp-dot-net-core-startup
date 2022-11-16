using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Entities;

namespace Module.Sales.Domain.Units
{
    public class UpdatePriceLevelCommandHandler : ICommandHandler<UpdatePriceLevelCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdatePriceLevelCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdatePriceLevelCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GetRepository<PriceLevel>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity != null)
            {
                request.Map(entity);
            }
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
