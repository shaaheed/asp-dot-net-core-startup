using Module.Sales.Domain.Taxes;
using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Products
{
    public class ProductListItemDto : GuidCodeNameDto
    {
        public bool IsSale { get; set; }
        public decimal? SalesPrice { get; set; }
        public GuidCodeNameDto SalesUnit { get; set; }
        public ICollection<TaxListItemDto> SalesTaxes { get; set; }
        public float StockQuantity { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Product, ProductListItemDto>> Selector()
        {
            return x => new ProductListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,

                IsSale = x.IsSale,
                SalesPrice = x.SalesPrice,

                SalesUnit = x.SalesUnitId != null ? new GuidCodeNameDto { Id = (Guid)x.SalesUnitId, Code = x.SalesUnit.Symbol, Name = x.SalesUnit.Name } : null,

                StockQuantity = x.StockQuantity,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
