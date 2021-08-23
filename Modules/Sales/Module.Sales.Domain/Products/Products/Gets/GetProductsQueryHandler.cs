using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;
using System.Linq;
using Module.Sales.Entities;
using Module.Sales.Domain.Taxes;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain.Products
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, PagedCollection<ProductListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProductsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedCollection<ProductListItemDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ListAsync(ProductListItemDto.Selector(), request.FilterOptions, cancellationToken);
            var productIds = products.Items.Select(x => x.Id).ToList();
            return products;
        }

        private ICollection<TaxListItemDto> GetTaxes<T>(List<Guid> productIds) where T : ProductTax
        {
            var taxes = _unitOfWork.GetRepository<T>()
                .Where(x => productIds.Contains(x.ProductId))
                .Select(x => new TaxListItemDto
                {
                    Id = x.TaxId,
                    Code = x.Tax.Code,
                    Name = x.Tax.Name,
                    IsCompoundTax = x.Tax.IsCompoundTax,
                    Rate = x.Tax.Rate,
                    CreatedAt = x.Tax.CreatedAt
                })
                .ToList();
            return taxes;
        }
    }
}
