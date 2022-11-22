using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Organizations.Entities;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Organizations.Domain
{
    public class UpdateOrganizationCurrencyCommandHandler : ICommandHandler<UpdateOrganizationCurrencyCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrganizationCurrencyCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateOrganizationCurrencyCommand request, CancellationToken cancellationToken)
        {
            var org = await _unitOfWork.GetRepository<OrganizationCurrency>()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (org == null)
                throw new NotFoundException("Organization currency not found");

            request.Map(org);

            //var newEvent = new OrganizationCurrencyUpdatedEvent();
            //newEvent.GenerateType();
            //org.Append(newEvent);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
