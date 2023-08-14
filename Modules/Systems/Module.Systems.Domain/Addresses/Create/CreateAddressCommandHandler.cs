using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Systems.Entities;
using System;

namespace Module.Systems.Domain
{
    public class CreateAddressCommandHandler : ICommandHandler<CreateAddressCommand, Guid?>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateAddressCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid?> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Map();
            var repo = _unitOfWork.GetRepository<Address>();
            await repo.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0) return entity.Id;
            return null;
        }
    }
}
