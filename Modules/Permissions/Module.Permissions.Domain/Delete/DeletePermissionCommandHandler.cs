using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using Module.Permissions.Entities;

namespace Module.Permissions.Data
{
    public class DeletePermissionCommandHandler : DeleteCommandHandler<Permission, DeletePermissionCommand>
    {
        public DeletePermissionCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
