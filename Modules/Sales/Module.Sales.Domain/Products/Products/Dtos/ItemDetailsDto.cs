using Msi.Domain.Abstractions;
using System;

namespace Module.Sales.Domain.Products
{
    public class ItemDetailsDto
    {
        public Guid Id { get; set; }
        public IdNameDto Item { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public bool IsPriceTaxInclusive { get; set; }
        public IdNameDto Unit { get; set; }
        public IdNameDto Tax { get; set; }
        public IdNameDto Account { get; set; }
        public IdNameDto Currency { get; set; }
    }
}
