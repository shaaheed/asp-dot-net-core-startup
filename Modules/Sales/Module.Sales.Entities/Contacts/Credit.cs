using Module.Payments.Entities;
using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class Credit : OrganizationEntity
    {
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }

        public Guid? PaymentId { get; set; }
        public Payment Payment { get; set; }

        public Guid? ReferenceId { get; set; }

        public decimal Amount { get; set; }

    }
}
