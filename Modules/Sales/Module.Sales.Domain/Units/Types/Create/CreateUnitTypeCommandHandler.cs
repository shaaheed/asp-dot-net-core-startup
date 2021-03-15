using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Products
{
    public class CreateUnitTypeCommandHandler : ICommandHandler<CreateUnitTypeCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateUnitTypeCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateUnitTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Map();
            var repo = _unitOfWork.GetRepository<UnitType>();
            await repo.AddAsync(entity, cancellationToken);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
