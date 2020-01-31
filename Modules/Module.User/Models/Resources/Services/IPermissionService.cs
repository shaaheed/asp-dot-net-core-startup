using Core.Infrastructure.Services;

namespace Comment.Application.Permissions
{
    public interface IPermissionService : IService
    {
        bool Authorise(long userId, string permission, string operation);
    }
}
