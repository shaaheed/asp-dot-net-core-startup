using Module.Users.Entities;
using Core.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Comment.Application.Permissions
{
    [ServiceLifetime(ServiceLifetime.Transient)]
    public class ResourceService : IResourceService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ResourceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ResourceExistById(long resourceId)
        {
            var exist = _unitOfWork.GetRepository<Resource>()
                .AsQueryable()
                .Select(x => x.Id)
                .Where(x => x == resourceId)
                .Count() > 0;
            return exist;
        }

        public async Task<bool> ResourceGroupAssociationExistByResourceId(long resourceId)
        {
            var exist = _unitOfWork.GetRepository<ResourceGroupAssociation>()
                .Where(x => x.ResourceId == resourceId)
                .Select(x => x.Id)
                .Count() > 0;
            return exist;
        }
    }
}
