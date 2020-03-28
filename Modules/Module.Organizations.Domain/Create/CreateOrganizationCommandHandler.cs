using Core.Infrastructure.Commands;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;
using Module.Organizations.Entities;

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
            newUser.Append(orgCreatedEvent);
            await orgRepo.AddAsync(newUser, cancellationToken);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
