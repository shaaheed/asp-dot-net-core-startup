﻿using Core.Infrastructure.Commands;
using Core.Infrastructure.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;
using Module.Permissions.Entities;

namespace Module.Permissions.Data
{
    public class DeletePermissionCommandHandler : ICommandHandler<DeletePermissionCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeletePermissionCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            var permissionRepo = _unitOfWork.GetRepository<Permission>();
            var permissionToBeDeleted = await permissionRepo.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (permissionToBeDeleted == null)
                throw new NotFoundException("Permission not found");

            permissionRepo.Remove(permissionToBeDeleted);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
