using Msi.Data.Entity;
using Module.Systems.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Module.Sales.Entities
{
    [IgnoredEntity]
    public abstract class AbstractDocument : OrganizationEntity
    {
        public string Number { get; set; }
        public string Reference { get; set; }

        public Guid? AccountId { get; set; }
        public Account Account { get; set; }

        /// <summary>
        /// Contact could be Customer, Supplier etc.
        /// </summary>
        public Guid? ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        /// <summary>
        /// Sum of all line items Subtotal
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Sum of all line items Total
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal GrandTotal { get; set; }

        /// <summary>
        /// Sum of all line item TotalTaxAmount
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalTaxAmount { get; set; }

        public DateTimeOffset IssueDate { get; set; }
        public string Note { get; set; }

        public Guid? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public float CurrencyExchangeRate { get; set; }

    }
}
