using Module.Sales.Entities;
using Module.Core.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Products
{
    public class ProductListItemDto : GuidCodeNameDto
    {
        public bool IsSale { get; set; }
        public decimal? SalesPrice { get; set; }
        public int StockQuantity { get; set; }
        
        public static Expression<Func<Product, ProductListItemDto>> Selector()
        {
            return x => new ProductListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,

                IsSale = x.IsSale,
                SalesPrice = x.SalesPrice,
               
                StockQuantity = x.StockQuantity
            };
        }
    }
}
