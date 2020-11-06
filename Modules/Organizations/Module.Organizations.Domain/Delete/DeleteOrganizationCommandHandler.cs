using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Organizations.Entities;
using Msi.Data.Abstractions;
using Msi.Core;

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
            var orgToBeDeleted = await orgRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (orgToBeDeleted == null)
                throw new NotFoundException("Organization not found");

            orgRepo.Remove(orgToBeDeleted);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
