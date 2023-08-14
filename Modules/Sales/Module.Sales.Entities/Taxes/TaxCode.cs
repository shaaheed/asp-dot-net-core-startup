using Module.Systems.Entities;
using System;

namespace Module.Sales.Entities
{
    public class TaxCode : OrganizationCodeNameEntity
    {
        public float Rate { get; set; }
        public string Description { get; set; }
        public string TaxNumber { get; set; }

        public DateTimeOffset? EffectiveFrom { get; set; }
        public DateTimeOffset? ValidUntil { get; set; }

        public Guid? PurchaseTaxAccountId { get; set; }
        public virtual Account PurchaseTaxAccount { get; set; }

        public Guid? SalesTaxAccountId { get; set; }
        public virtual Account SalesTaxAccount { get; set; }

        public TaxAvailableOn AvailableOn { get; set; }

        public bool ShowTaxNumberOnInvoice { get; set; }
        public bool IsCompoundTax { get; set; }
    }
}
