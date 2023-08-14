using Module.Sales.Entities;
using Msi.Domain.Abstractions;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Products
{
    public class SaleDetailsDto : ItemDetailsDto
    {
        public decimal? AveragePrice { get; set; }
        public decimal? MRP { get; set; }

        public static Expression<Func<SaleDetails, SaleDetailsDto>> Selector()
        {
            return x => new SaleDetailsDto
            {
                Id = x.Id,
                Description = x.Description,
                Price = x.Price,
                MRP = x.MRP,
                Unit = x.UnitId != null ? new IdNameDto
                {
                    Id = x.Unit.Id,
                    Name = x.Unit.Name
                } : null,
                Account = x.AccountId != null ? new IdNameDto
                {
                    Id = (Guid)x.AccountId,
                    Name = x.Account.Name,
                } : null,
                AveragePrice = x.AveragePrice,
                IsPriceTaxInclusive = x.IsPriceTaxInclusive,
                Tax = x.TaxId != null ? new IdNameDto
                {
                    Id = (Guid)x.TaxId,
                    Name = x.Tax.Name,
                } : null,
                Currency = x.CurrencyId != null ? new IdNameDto
                {
                    Id = (Guid)x.CurrencyId,
                    Name = x.Currency.Name,
                } : null,
                Item = new IdNameDto
                {
                    Id = x.ItemId,
                    Name = x.Item.Name,
                }
            };
        }
    }
}
