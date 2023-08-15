using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using System.Linq;

namespace Module.Sales.Domain.Items
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemService _itemService;

        public CreateItemCommandHandler(
            IUnitOfWork unitOfWork,
            IItemService itemService)
        {
            _unitOfWork = unitOfWork;
            _itemService = itemService;
        }

        public async Task<long> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = request.Map();
            var repo = _unitOfWork.GetRepository<Item>();
            await repo.AddAsync(item, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _itemService.CreateOrUpdateCategories(item.Id, request.Categories);
            await _itemService.CreateOrUpdateSaleDetails(item.Id, request.SaleDetails, cancellationToken);
            await _itemService.CreateOrUpdatePurchaseDetails(item.Id, request.PurchaseDetails, cancellationToken);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
