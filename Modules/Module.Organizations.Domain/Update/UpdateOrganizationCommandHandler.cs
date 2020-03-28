using Core.Infrastructure.Commands;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;
using Module.Organizations.Entities;

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
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if(org != null)
            {
                org.Name = request.Name;
                var newEvent = new OrganizationUpdatedEvent();
                newEvent.GenerateType();
                org.Append(newEvent);
            }            
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
