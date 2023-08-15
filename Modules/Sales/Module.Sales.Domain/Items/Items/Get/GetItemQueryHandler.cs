using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using Module.Systems.Domain;

namespace Module.Sales.Domain.Items
{
    public class GetItemQueryHandler : IQueryHandler<GetItemQuery, ItemDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetItemQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ItemDto> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetAsync(x => x.Id == request.Id, ItemDto.Selector(), cancellationToken);
            if (item != null)
            {
                var categories = _unitOfWork.GetRepository<ItemCategory>()
                    .WhereAsReadOnly(x => x.ItemId == request.Id)
                    .Select(x => new GuidIdNameDto
                    {
                        Id = x.CategoryId,
                        Name = x.Category.Name
                    });
                item.Categories = categories;
                item.SaleDetails = await _unitOfWork.GetAsync(x => x.ItemId == item.Id, ItemSaleDetailsDto.Selector(), cancellationToken);
                if (item.SaleDetails != null)
                {
                    item.SaleDetails.Currencies = _unitOfWork.GetRepository<ItemSaleDetailsCurrency>()
                        .WhereAsReadOnly(x => x.ItemSaleDetailsId == item.SaleDetails.Id)
                        .Select(x => new GuidIdNameDto
                        {
                            Id = x.CurrencyId,
                            Name = x.Currency.Name,
                        });
                }
                item.PurchaseDetails = await _unitOfWork.GetAsync(x => x.ItemId == item.Id, ItemPurchaseDetailsDto.Selector(), cancellationToken);
                if (item.PurchaseDetails != null)
                {
                    item.PurchaseDetails.Currencies = _unitOfWork.GetRepository<ItemPurchaseDetailsCurrency>()
                        .WhereAsReadOnly(x => x.ItemPurchaseDetailsId == item.PurchaseDetails.Id)
                        .Select(x => new GuidIdNameDto
                        {
                            Id = x.CurrencyId,
                            Name = x.Currency.Name,
                        });
                }
            }
            return item;
        }
    }
}
