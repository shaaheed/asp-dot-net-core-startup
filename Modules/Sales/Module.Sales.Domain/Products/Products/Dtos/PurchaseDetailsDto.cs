using Module.Sales.Entities;
using Msi.Domain.Abstractions;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Products
{
    public class PurchaseDetailsDto : ItemDetailsDto
    {
        public decimal? AverageCost { get; set; }
        public decimal? LastPurchasePrice { get; set; }
        public decimal? TotalValue { get; set; }
        public IdNameDto Supplier { get; set; }
        public IdNameDto Location { get; set; }

        public static Expression<Func<PurchaseDetails, PurchaseDetailsDto>> Selector()
        {
            return x => new PurchaseDetailsDto
            {
                Id = x.Id,
                Description = x.Description,
                Price = x.Price,
                IsPriceTaxInclusive = x.IsPriceTaxInclusive,
                AverageCost = x.AverageCost,
                LastPurchasePrice = x.LastPurchasePrice,
                TotalValue = x.TotalValue,
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
                Tax = x.TaxId != null ? new IdNameDto
                {
                    Id = (Guid)x.TaxId,
                    Name = x.Tax.Name,
                } : null,
                Location = x.LocationId != null ? new IdNameDto
                {
                    Id = (Guid)x.LocationId,
                    Name = x.Location.Name,
                } : null,
                Supplier = x.SupplierId != null ? new IdNameDto
                {
                    Id = (Guid)x.SupplierId,
                    Name = x.Supplier.DisplayName,
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
