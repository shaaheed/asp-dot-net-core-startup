using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Units
{
    public class CreateTermCommandHandler : ICommandHandler<CreateTermCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateTermCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateTermCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Map();
            var repo = _unitOfWork.GetRepository<Term>();
            await repo.AddAsync(entity, cancellationToken);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
