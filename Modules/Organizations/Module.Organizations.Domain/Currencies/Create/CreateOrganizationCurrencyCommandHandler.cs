using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Organizations.Entities;
using Msi.Data.Abstractions;

namespace Module.Organizations.Domain
{
    public class CreateOrganizationCurrencyCommandHandler : ICommandHandler<CreateOrganizationCurrencyCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateOrganizationCurrencyCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateOrganizationCurrencyCommand request, CancellationToken cancellationToken)
        {
            var orgRepo = _unitOfWork.GetRepository<OrganizationCurrency>();
            var entity = request.Map();
            await orgRepo.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
