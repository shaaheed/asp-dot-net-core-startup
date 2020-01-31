using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Comment.Application.Permissions;
using Module.Users.Entities;
using Core.Infrastructure.Commands;
using Msi.UtilityKit;
using Msi.Extensions.Persistence.Abstractions;

namespace Modules.User.Resources.Commands
{
    public class PermissionCommandHandler :
        ICommandHandler<SeedPermissionsCommand, object>,
        ICommandHandler<CreateResourceGroupCommand, object>,
        ICommandHandler<DeleteResourceGroupsCommand, object>,
        ICommandHandler<EditResourceGroupsCommand, object>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Resource> _resourceRepository;
        private readonly IRepository<Operation> _operationRepository;
        private readonly IRepository<ResourceOperation> _resourceOperationRepository;
        private readonly IResourceService _resourceService;

        public PermissionCommandHandler(
            IUnitOfWork unitOfWork,
            IResourceService resourceService)
        {
            _unitOfWork = unitOfWork;
            _resourceRepository = unitOfWork.GetRepository<Resource>();
            _operationRepository = unitOfWork.GetRepository<Operation>();
            _resourceOperationRepository = unitOfWork.GetRepository<ResourceOperation>();
            _resourceService = resourceService;
        }

        public async Task<object> Handle(SeedPermissionsCommand request, CancellationToken cancellationToken)
        {

            foreach (var reqResource in request.Resources)
            {

                // Resource
                var resource = await _resourceRepository.FirstOrDefaultAsync(x => x.Code == reqResource.Key);
                if (resource == null)
                {
                    resource = new Resource
                    {
                        Code = reqResource.Key,
                        Name = reqResource.Key.ToUpperFirstLetter(),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    await _resourceRepository.AddAsync(resource);
                    await _unitOfWork.SaveChangesAsync();
                }

                // Resource Operation
                foreach (var reqOperation in reqResource.Value)
                {
                    var operation = await _operationRepository.FirstOrDefaultAsync(x => x.Code == reqOperation);
                    if (operation == null)
                    {
                        operation = new Operation
                        {
                            Code = reqOperation,
                            Name = reqOperation.ToUpperFirstLetter(),
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        };
                        await _operationRepository.AddAsync(operation);
                        await _unitOfWork.SaveChangesAsync();
                    }

                    var resourceOperation = await _resourceOperationRepository.FirstOrDefaultAsync(x => x.ResourceId == resource.Id && x.OperationId == operation.Id);
                    if (resourceOperation == null)
                    {
                        resourceOperation = new ResourceOperation
                        {
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                            OperationId = operation.Id,
                            ResourceId = resource.Id
                        };
                        await _resourceOperationRepository.AddAsync(resourceOperation);
                    }

                }

            }

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<object> Handle(CreateResourceGroupCommand request, CancellationToken cancellationToken)
        {

            var resourceGroupRepo = _unitOfWork.GetRepository<ResourceGroup>();
            var resourceGroup = await resourceGroupRepo.FirstOrDefaultAsync(x => x.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase));
            if (resourceGroup == null)
            {
                resourceGroup = new ResourceGroup
                {
                    Name = request.Name,
                    Code = request.Name,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                await resourceGroupRepo.AddAsync(resourceGroup);

                var resourceRepo = _unitOfWork.GetRepository<Resource>();
                var operationRepo = _unitOfWork.GetRepository<Operation>();
                var resourceGroupAssociationRepo = _unitOfWork.GetRepository<ResourceGroupAssociation>();
                var resourceGroupAssociationOperationRepo = _unitOfWork.GetRepository<ResourceGroupAssociationOperation>();

                foreach (var resourceOperation in request.Resources)
                {
                    var resource = await resourceRepo.FirstOrDefaultAsync(x => x.Id == resourceOperation.ResourceId);
                    if (resource != null)
                    {
                        var resourceGroupAssociation = new ResourceGroupAssociation
                        {
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                            ResourceId = resource.Id,
                            ResourceGroupId = resourceGroup.Id
                        };
                        await resourceGroupAssociationRepo.AddAsync(resourceGroupAssociation);

                        if (resourceOperation.OperationIds != null && resourceOperation.OperationIds.Count() > 0)
                        {
                            foreach (var operationId in resourceOperation.OperationIds)
                            {
                                var operation = await operationRepo.FirstOrDefaultAsync(x => x.Id == operationId);
                                if (operation != null)
                                {
                                    var resourceGroupAssociationOperation = new ResourceGroupAssociationOperation
                                    {
                                        CreatedAt = DateTime.UtcNow,
                                        UpdatedAt = DateTime.UtcNow,
                                        OperationId = (long)operationId,
                                        ResourceGroupAssociationId = resourceGroupAssociation.Id
                                    };
                                    await resourceGroupAssociationOperationRepo.AddAsync(resourceGroupAssociationOperation);
                                }
                            }
                        }

                    }
                }

            }

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<object> Handle(DeleteResourceGroupsCommand request, CancellationToken cancellationToken)
        {

            if (request.Ids != null && request.Ids.Length > 0)
            {
                var resourceGroupRepo = _unitOfWork.GetRepository<ResourceGroup>();
                var resourceGroupIds = resourceGroupRepo
                    .Where(x => request.Ids.Contains(x.Id))
                    .Select(x => x.Id)
                    .ToList();

                //foreach (var resourceGroupId in resourceGroupIds)
                //{
                //    await DeleteResourceGroupRelatedData(resourceGroupId);
                //}

                var resourceGroupsToBeDeleted = resourceGroupIds.Select(x => new ResourceGroup
                {
                    Id = x
                });
                resourceGroupRepo.RemoveRange(resourceGroupsToBeDeleted);
            }

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<object> Handle(EditResourceGroupsCommand request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                var resourceGroup = await _unitOfWork.GetRepository<ResourceGroup>()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (resourceGroup != null)
                {

                    var resourceGroupAssociationRepo = _unitOfWork.GetRepository<ResourceGroupAssociation>();
                    var resourceRepo = _unitOfWork.GetRepository<Resource>();

                    long[] resourceIds = request.Resources.Select(x => x.ResourceId).ToArray();
                    await DeleteResourceGroupAssociationsAsync(resourceGroup.Id, resourceIds);

                    resourceGroup.Name = request.Name;
                    resourceGroup.UpdatedAt = DateTime.UtcNow;

                    foreach (var requestResource in request.Resources)
                    {

                        var resourceExist = await _resourceService.ResourceExistById(requestResource.ResourceId);
                        if (resourceExist)
                        {
                            var resourceGroupAssociationId = resourceGroupAssociationRepo
                                .Where(x => x.ResourceId == requestResource.ResourceId && x.ResourceGroupId == resourceGroup.Id)
                                .Select(x => x.Id)
                                .FirstOrDefault();

                            if (resourceGroupAssociationId <= 0)
                            {
                                await CreateResourceGroupAssociationAsync(resourceGroup.Id, requestResource);
                            }
                            else
                            {
                                var operationIds = requestResource.OperationIds.Select(x => (long)x).ToArray();
                                await UpdateResourceGroupAssociationsAsync(resourceGroupAssociationId, operationIds);
                            }

                        }
                    }

                }
            }

            return await _unitOfWork.SaveChangesAsync();
        }

        private async Task DeleteResourceGroupAssociationsAsync(long resourceGroupId, long[] resourceIds)
        {
            var resourceGroupAssociationRepo = _unitOfWork.GetRepository<ResourceGroupAssociation>();
            var dbResourceGroupAssociations = resourceGroupAssociationRepo
                        .Where(x => x.ResourceGroupId == resourceGroupId)
                        .Select(x => new { Id = x.Id, ResourceId = x.ResourceId })
                        .ToList();

            var dbResourceGroupAssociationToBeDeleted = dbResourceGroupAssociations
                .Where(x => !resourceIds.Contains(x.ResourceId))
                .Select(x => new ResourceGroupAssociation { Id = x.Id });

            if (dbResourceGroupAssociationToBeDeleted.Count() > 0)
            {
                resourceGroupAssociationRepo.RemoveRange(dbResourceGroupAssociationToBeDeleted);
            }
        }

        private async Task CreateResourceGroupAssociationAsync(long resourceGroupId, CreateEditResourceGroupCommandModel resource)
        {

            var resourceGroupAssociationRepo = _unitOfWork.GetRepository<ResourceGroupAssociation>();
            var resourceGroupAssociationOperationRepo = _unitOfWork.GetRepository<ResourceGroupAssociationOperation>();

            var rsourceGroupAssociation = new ResourceGroupAssociation
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                ResourceId = resource.ResourceId,
                ResourceGroupId = resourceGroupId,
            };
            await resourceGroupAssociationRepo.AddAsync(rsourceGroupAssociation);

            foreach (var operationId in resource.OperationIds)
            {
                var operationExist = _unitOfWork.GetRepository<Operation>()
                    .Where(x => x.Id == operationId)
                    .Select(x => x.Id)
                    .Count() > 0;

                if (operationExist)
                {
                    var resourceGroupAssociationOperation = new ResourceGroupAssociationOperation
                    {
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        OperationId = (long)operationId,
                        ResourceGroupAssociationId = rsourceGroupAssociation.Id
                    };
                    await resourceGroupAssociationOperationRepo.AddAsync(resourceGroupAssociationOperation);
                }
            }
        }

        private async Task UpdateResourceGroupAssociationsAsync(long resourceGroupAssociationId, long[] operationIds)
        {

            var resourceGroupAssociationRepo = _unitOfWork.GetRepository<ResourceGroupAssociation>();
            var resourceGroupAssociationOperationRepo = _unitOfWork.GetRepository<ResourceGroupAssociationOperation>();

            var dbResourceGroupAssociationOperationIds = resourceGroupAssociationOperationRepo
                .Where(x => x.ResourceGroupAssociationId == resourceGroupAssociationId)
                .Select(x => new { Id = x.Id, OperationId = x.OperationId })
                .ToList();

            var validOperationIds = _unitOfWork.GetRepository<Operation>()
                .Where(x => operationIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            var resourceGroupAssociationOperationsToBeDelete = dbResourceGroupAssociationOperationIds
                .Where(x => !validOperationIds.Contains(x.OperationId))
                .Select(x => new ResourceGroupAssociationOperation { Id = x.Id });

            if (resourceGroupAssociationOperationsToBeDelete.Count() > 0)
            {
                resourceGroupAssociationOperationRepo.RemoveRange(resourceGroupAssociationOperationsToBeDelete);
            }

            var resourceGroupAssociationOperationsToBeAdd = validOperationIds
                .Where(x => !dbResourceGroupAssociationOperationIds.Select(y => y.OperationId).Contains(x))
                .Select(x => new ResourceGroupAssociationOperation
                {
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    OperationId = x,
                    ResourceGroupAssociationId = resourceGroupAssociationId
                });

            if (resourceGroupAssociationOperationsToBeAdd.Count() > 0)
            {
                await resourceGroupAssociationOperationRepo.AddRangeAsync(resourceGroupAssociationOperationsToBeAdd);
            }

        }

    }
}
