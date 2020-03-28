using Core.Interfaces.Entities;
using Module.Core.Entities;
using Module.Users.Entities;
using System;
using System.Collections.Generic;

namespace Module.Sales.Entities
{
    public class Qoute : BaseEntity
    {
        public Qoute()
        {
            QouteLineItems = new HashSet<QouteLineItem>();
        }

        public string Code { get; set; }

        public long? CustomerId { get; set; }
        public User Customer { get; set; }

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
        public string Memo { get; set; }

        public DateTimeOffset ExpiresOn { get; set; }
        public long? CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public int TotalConvertedInvoice { get; set; }

        public virtual ICollection<QouteLineItem> QouteLineItems { get; set; }

        public void Calculate()
        {
            GrandTotal = 0;
            Subtotal = 0;
            foreach (var item in QouteLineItems)
            {
                GrandTotal += item.LineItem.Total;
                Subtotal += item.LineItem.Subtotal;
            }
        }

    }
}
