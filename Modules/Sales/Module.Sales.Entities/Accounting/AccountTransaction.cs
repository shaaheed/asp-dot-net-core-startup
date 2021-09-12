using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class AccountTransaction : IOrganizationEntity
    {
        public Guid? OrganizationId { get ; set; }
        public AccountTransactionType Type { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }

        public decimal Amount { get; set; }
        public bool IsDebit { get; set; }
        public bool IsCredit { get; set; }
        public float Quantity { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        public DateTimeOffset? ReconciledDate { get; set; }
    }
}
