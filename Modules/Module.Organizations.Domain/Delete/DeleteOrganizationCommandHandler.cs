using Core.Infrastructure.Commands;
using Core.Infrastructure.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;
using Module.Organizations.Entities;

namespace Module.Organizations.Domain
{
    public class DeleteOrganizationCommandHandler : ICommandHandler<DeleteOrganizationCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrganizationCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            var orgRepo = _unitOfWork.GetRepository<Organization>();
            var orgToBeDeleted = await orgRepo.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (orgToBeDeleted == null)
                throw new NotFoundException("Organization not found");

            orgRepo.Remove(orgToBeDeleted);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
