using Msi.Data.Entity;
using Module.Systems.Entities;
using System;

namespace Module.Sales.Entities
{
    [IgnoredEntity]
    public class BaseQuote : OrganizationBaseEntity
    {
        public string Number { get; set; }
        public string Reference { get; set; }

        public Guid? AccountId { get; set; }
        public ChartOfAccount Account { get; set; }

        /// <summary>
        /// Sum of all line items Subtotal
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Sum of all line items Total
        /// </summary>
        public decimal GrandTotal { get; set; }

        /// <summary>
        /// Sum of all line item TotalTaxAmount
        /// </summary>
        public decimal TotalTaxAmount { get; set; }

        public DateTimeOffset IssueDate { get; set; }
        public string Note { get; set; }

        public Guid? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

    }
}
