using Core.Infrastructure.Commands;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;
using Module.Permissions.Entities;

namespace Module.Permissions.Domain
{
    public class UpdatePermissionCommandHandler : ICommandHandler<UpdatePermissionCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdatePermissionCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _unitOfWork.GetRepository<Permission>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if(permission != null)
            {
                permission.Name = request.Name;
                permission.Group = request.Group;
                permission.Description = request.Description;

                var newEvent = new PermissionUpdatedEvent();
                newEvent.GenerateType();
                permission.Append(newEvent);
            }            
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
