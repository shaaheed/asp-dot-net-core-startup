using Core.Infrastructure.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;
using Module.Permissions.Entities;

namespace Module.Permissions.Domain
{
    public class GetOrganizationsQueryHandler : IQueryHandler<GetPermissionsQuery, IEnumerable<PermissionDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetOrganizationsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            var results = _unitOfWork.GetRepository<Permission>()
                .AsQueryable()
                .Select(x => new PermissionDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Group = x.Group,
                    Description = x.Description
                })
                .ToList();
            return await Task.FromResult(results);
        }
    }
}
