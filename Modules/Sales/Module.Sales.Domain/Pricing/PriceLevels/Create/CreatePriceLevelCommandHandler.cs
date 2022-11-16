using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class CreatePriceLevelCommandHandler : ICommandHandler<CreatePriceLevelCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreatePriceLevelCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreatePriceLevelCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Map();
            var repo = _unitOfWork.GetRepository<PriceLevel>();
            await repo.AddAsync(entity, cancellationToken);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
