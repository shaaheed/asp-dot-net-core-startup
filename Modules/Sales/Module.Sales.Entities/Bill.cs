using Msi.Data.Entity;
using Module.Accounting.Entities;
using Module.Users.Entities;
using System;
using System.Collections.Generic;

namespace Module.Sales.Entities
{
    public class Bill : BaseEntity
    {

        public Bill()
        {
            BillLineItems = new HashSet<BillLineItem>();
        }

        public string Code { get; set; }
        public BillStatus Status { get; set; } = BillStatus.Unpaid;

        public Guid? VendorId { get; set; }
        public User Vendor { get; set; }

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
        public bool Pinned { get; set; }
        public string Note { get; set; }

        //public long? ChartOfAccountId { get; set; }
        //public ChartOfAccount ChartOfAccount { get; set; }

        public virtual ICollection<BillLineItem> BillLineItems { get; set; }
        public virtual ICollection<BillPayment> BillPayments { get; set; }

        public void Calculate()
        {
            GrandTotal = 0;
            Subtotal = 0;
            foreach (var item in BillLineItems)
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
                Status = BillStatus.Paid;
                AmountDue = 0;
            }
            else if (GrandTotal > paymentAmount)
            {
                Status = BillStatus.Due;
            }

            if (paymentAmount <= GrandTotal)
            {
                AmountDue = GrandTotal - paymentAmount;
            }
        }
    }
}
