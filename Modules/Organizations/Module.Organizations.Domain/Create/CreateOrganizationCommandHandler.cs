using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Organizations.Entities;
using Msi.Data.Abstractions;

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
            Organization newUser = new Organization
            {
                Name = request.Name,
            };
            var orgCreatedEvent = new OrganizationCreatedEvent();
            //newUser.Append(orgCreatedEvent);
            await orgRepo.AddAsync(newUser, cancellationToken);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
