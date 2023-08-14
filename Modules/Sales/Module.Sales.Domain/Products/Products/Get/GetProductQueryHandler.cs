using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using Module.Systems.Domain;

namespace Module.Sales.Domain.Products
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProductQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetAsync(x => x.Id == request.Id, ProductDto.Selector(), cancellationToken);
            if (item != null)
            {
                var categories = _unitOfWork.GetRepository<ItemCategory>()
                    .Where(x => x.ItemId == request.Id)
                    .Select(x => new GuidIdNameDto
                    {
                        Id = x.CategoryId,
                        Name = x.Category.Name
                    });
                item.Categories = categories;
                item.SaleDetails = await _unitOfWork.GetAsync(x => x.ItemId == item.Id, SaleDetailsDto.Selector(), cancellationToken);
                item.PurchaseDetails = await _unitOfWork.GetAsync(x => x.ItemId == item.Id, PurchaseDetailsDto.Selector(), cancellationToken);
            }
            return item;
        }
    }
}
