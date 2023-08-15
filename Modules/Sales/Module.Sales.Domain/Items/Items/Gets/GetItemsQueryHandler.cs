using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Module.Sales.Domain.Items
{
    public class GetItemsQueryHandler : IQueryHandler<GetItemsQuery, PagedCollection<ItemListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetItemsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedCollection<ItemListItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ListAsync(ItemListItemDto.Selector(), request.FilterOptions, cancellationToken);
            var productIds = products.Items.Select(x => x.Id).ToList();
            return products;
        }

        //private ICollection<TaxListItemDto> GetTaxes<T>(List<Guid> productIds) where T : ProductTax
        //{
        //    var taxes = _unitOfWork.GetRepository<T>()
        //        .Where(x => productIds.Contains(x.ProductId))
        //        .Select(x => new TaxListItemDto
        //        {
        //            Id = x.TaxId,
        //            Code = x.Tax.Code,
        //            Name = x.Tax.Name,
        //            IsCompoundTax = x.Tax.IsCompoundTax,
        //            Rate = x.Tax.Rate,
        //            CreatedAt = x.Tax.CreatedAt
        //        })
        //        .ToList();
        //    return taxes;
        //}
    }
}
