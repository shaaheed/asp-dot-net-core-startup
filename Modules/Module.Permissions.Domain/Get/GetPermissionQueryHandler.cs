using Core.Infrastructure.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Permissions.Entities;

namespace Module.Permissions.Domain
{
    public class GetPermissionQueryHandler : IQueryHandler<GetPermissionQuery, PermissionDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetPermissionQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PermissionDto> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
        {
            var permission = _unitOfWork.GetRepository<Permission>()
                .AsQueryable()
                .Select(x => new PermissionDto
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .FirstOrDefault(x => x.Id == request.Id);
            return await Task.FromResult(permission);
        }
    }
}
