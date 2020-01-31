using Module.Users.Entities;
using Core.Infrastructure.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Modules.User.Resources.Queries
{
    public class PermissionQueryHandler :
        IQueryHandler<ScanPermissionsQuery, object>,
        IQueryHandler<GetResourcesQuery, object>,
        IQueryHandler<GetResourceGroupsQuery, object>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Resource> _resourceRepository;
        private readonly IRepository<Operation> _operationRepository;

        public PermissionQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _resourceRepository = unitOfWork.GetRepository<Resource>();
            _operationRepository = unitOfWork.GetRepository<Operation>();
        }

        public Task<object> Handle(ScanPermissionsQuery request, CancellationToken cancellationToken)
        {
            return null;
        }

        public async Task<object> Handle(GetResourcesQuery request, CancellationToken cancellationToken)
        {
            var result = _resourceRepository
                .AsQueryable()
                .Select(x => new
                {
                    Id = x.Id,
                    Code = x.Code,
                    Operations = x.ResourceOperations.Select(y => new
                    {
                        Id = y.OperationId,
                        Code = y.Operation.Code
                    }).ToList()
                })
                .ToList();
            return result;
        }

        public async Task<object> Handle(GetResourceGroupsQuery request, CancellationToken cancellationToken)
        {
            var resourceGroupsRepo = _unitOfWork.GetRepository<ResourceGroup>();
            return resourceGroupsRepo
                .AsQueryable()
                .Select(x => new
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    Resources = x.ResourceGroupAssociations.Select(y => new
                    {
                        Id = y.ResourceId,
                        Name = y.Resource.Name,
                        Code = y.Resource.Code,
                        Operations = y.ResourceGroupAssociationOperations.Select(z => new {
                            Id = z.OperationId,
                            Code = z.Operation.Code,
                            Name = z.Operation.Name
                        })
                    })
                }).ToList();
        }
    }
}
