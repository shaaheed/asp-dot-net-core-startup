using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Entities;

namespace Module.Sales.Domain.Items
{
    public class UpdateItemCommandHandler : ICommandHandler<UpdateItemCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemService _itemService;

        public UpdateItemCommandHandler(
            IUnitOfWork unitOfWork,
            IItemService itemService)
        {
            _unitOfWork = unitOfWork;
            _itemService = itemService;
        }

        public async Task<long> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<Item>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (item != null)
            {
                request.Map(item);
                await _itemService.CreateOrUpdateCategories(item.Id, request.Categories);
                await _itemService.CreateOrUpdateSaleDetails(item.Id, request.SaleDetails);
                await _itemService.CreateOrUpdatePurchaseDetails(item.Id, request.PurchaseDetails);
            }
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
