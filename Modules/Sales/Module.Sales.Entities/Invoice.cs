using Msi.Data.Entity;
using Module.Accounting.Entities;
using Module.Users.Entities;
using System;
using System.Collections.Generic;

namespace Module.Sales.Entities
{
    public class Invoice : BaseEntity
    {

        public Invoice()
        {
            InvoiceLineItems = new HashSet<InvoiceLineItem>();
        }

        public string Code { get; set; }
        public InvoiceStatus Status { get; set; }

        public Guid? CustomerId { get; set; }
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

        public decimal AmountDue { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset PaymentDueDate { get; set; }
        public bool Pinned { get; set; }
        public string Note { get; set; }
        public string Memo { get; set; }

        //public long? ChartOfAccountId { get; set; }
        //public ChartOfAccount ChartOfAccount { get; set; }

        public long? ConvertedFromQouteId { get; set; }
        public Qoute ConvertedFromQoute { get; set; }

        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
        public virtual ICollection<InvoicePayment> InvoicePayments { get; set; }

        public void Calculate()
        {
            GrandTotal = 0;
            Subtotal = 0;
            foreach (var item in InvoiceLineItems)
            {
                GrandTotal += item.LineItem.Total;
                Subtotal += item.LineItem.Subtotal;
            }
        }

        public void AddPayment(decimal paymentAmount)
        {
            if(GrandTotal == paymentAmount)
            {
                // Full payment
                Status = InvoiceStatus.Paid;
                AmountDue = 0;
            }
            else if (GrandTotal > paymentAmount)
            {
                Status = InvoiceStatus.Due;
            }

            if (paymentAmount <= GrandTotal)
            {
                AmountDue = GrandTotal - paymentAmount;
            }
        }
    }
}
