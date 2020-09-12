using Core.Infrastructure.Commands;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Permissions.Entities;

namespace Module.Permissions.Data
{
    public class CreatePermissionCommandHandler : ICommandHandler<CreatePermissionCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreatePermissionCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {

            var permissionRepo = _unitOfWork.GetRepository<Permission>();
            Permission newPermission = new Permission
            {
                Id = request.Id,
                Name = request.Name,
                Group = request.Group,
                Description = request.Description
            };
            var permissionCreatedEvent = new PermissionCreatedEvent();
            newPermission.Append(permissionCreatedEvent);
            await permissionRepo.AddAsync(newPermission, cancellationToken);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
