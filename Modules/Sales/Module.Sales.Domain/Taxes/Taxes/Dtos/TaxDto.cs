using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Taxes
{
    public class TaxDto : GuidCodeNameDto
    {
        public float Rate { get; set; }
        public string Description { get; set; }
        public string TaxNumber { get; set; }
        public bool ShowTaxNumberOnInvoice { get; set; }
        public bool IsCompoundTax { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<TaxCode, TaxDto>> Selector()
        {
            return x => new TaxDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Description = x.Description,
                IsCompoundTax = x.IsCompoundTax,
                Rate = x.Rate,
                TaxNumber = x.TaxNumber,
                ShowTaxNumberOnInvoice = x.ShowTaxNumberOnInvoice,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
