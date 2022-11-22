using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Organizations.Entities;
using Msi.Data.Abstractions;
using Module.Systems.Entities;

namespace Module.Organizations.Domain
{
    public class CreateOrganizationCommandHandler : ICommandHandler<CreateOrganizationCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateOrganizationCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {

            var orgRepo = _unitOfWork.GetRepository<Organization>();
            var entity = request.Map();

            Address address = null;
            int result = 0;
            if (!string.IsNullOrWhiteSpace(request.Mobile) || !string.IsNullOrWhiteSpace(request.Address))
            {
                address = new Address
                {
                    AddressLine1 = request.Address,
                    Phone = request.Mobile
                };
                await _unitOfWork.GetRepository<Address>().AddAsync(address, cancellationToken);
                result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            if (address != null)
            {
                entity.AddressId = address.Id;
            }

            // var orgCreatedEvent = new OrganizationCreatedEvent();
            //newUser.Append(orgCreatedEvent);
            await orgRepo.AddAsync(entity, cancellationToken);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
