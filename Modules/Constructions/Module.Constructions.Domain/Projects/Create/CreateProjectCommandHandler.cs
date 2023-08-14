using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Constructions.Entities;
using Module.Systems.Entities;

namespace Module.Constructions.Domain
{
    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Project>();
            var entity = request.Map();

            int result = 0;

            if (request.Address != null)
            {
                var address = request.Address.Map();
                var addressRepo = _unitOfWork.GetRepository<Address>();
                await addressRepo.AddAsync(address);
                result += await _unitOfWork.SaveChangesAsync(cancellationToken);
                if (result > 0)
                {
                    entity.AddressId = address.Id;
                }
            }

            await repo.AddAsync(entity, cancellationToken);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
