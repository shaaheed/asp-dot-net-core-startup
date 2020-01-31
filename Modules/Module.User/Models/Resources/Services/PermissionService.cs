using Core.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Msi.Extensions.Persistence.Abstractions;

namespace Comment.Application.Permissions
{
    [ServiceLifetime(ServiceLifetime.Transient)]
    public class PermissionService : IPermissionService
    {

        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Authorise(long userId, string permission, string operation)
        {

            // find user group id


            //var martrix = _unitOfWork.GetRepository<PermissionMatrix>()
            //    .Where(x => x.UserId == userId && x.Permission.Code == permission && x.Operation.Code == operation);


            return true;
        }


    }
}
