using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Organizations.Entities;
using Msi.Data.Abstractions;
using Msi.Core;
using Module.Systems.Entities;

namespace Module.Organizations.Domain
{
    public class UpdateOrganizationCommandHandler : ICommandHandler<UpdateOrganizationCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrganizationCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var org = await _unitOfWork.GetRepository<Organization>()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (org == null)
                throw new NotFoundException("Organization not found");

            request.Map(org);

            var result = 0;
            if (!string.IsNullOrWhiteSpace(request.Address) || !string.IsNullOrWhiteSpace(request.Mobile))
            {
                if (org.AddressId != null)
                {
                    var address = await  _unitOfWork.GetRepository<Address>()
                        .FirstOrDefaultAsync(x => x.Id == org.AddressId && !x.IsDeleted, false, cancellationToken);
                    if (address != null)
                    {
                        address.Phone = request.Mobile;
                        address.AddressLine1 = request.Address;
                    }
                }
                else
                {
                    var address = new Address {
                        AddressLine1 = request.Address,
                        Phone = request.Mobile
                    };
                    await _unitOfWork.GetRepository<Address>().AddAsync(address, cancellationToken);
                    result += await _unitOfWork.SaveChangesAsync(cancellationToken);
                    org.AddressId = address.Id;
                }
            }

            //var newEvent = new OrganizationUpdatedEvent();
            //newEvent.GenerateType();
            //org.Append(newEvent);
            
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
