using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Taxes
{
    public class UpdateTaxCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float Rate { get; set; }
        public string Description { get; set; }
        public string TaxNumber { get; set; }
        public bool ShowTaxNumberOnInvoice { get; set; }
        public bool IsCompoundTax { get; set; }

        public virtual Tax Map(Tax entity = null)
        {
            entity = entity ?? new Tax();
            entity.Name = Name;
            entity.Code = Code;
            entity.Description = Description;
            entity.Rate = Rate;
            entity.TaxNumber = TaxNumber;
            entity.ShowTaxNumberOnInvoice = ShowTaxNumberOnInvoice;
            entity.IsCompoundTax = IsCompoundTax;
            return entity;
        }
    }
}
