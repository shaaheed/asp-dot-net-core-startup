using Core.Infrastructure.Services;
using System.Threading.Tasks;

namespace Comment.Application.Permissions
{
    public interface IResourceService : IService
    {
        Task<bool> ResourceExistById(long resourceId);

        Task<bool> ResourceGroupAssociationExistByResourceId(long resourceId);
    }
}
