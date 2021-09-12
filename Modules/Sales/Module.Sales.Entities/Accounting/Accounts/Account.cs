using Module.Systems.Entities;
using System;

namespace Module.Sales.Entities
{
    // Chart of account
    public class Account : OrganizationCodeNameEntity
    {
        public string Description { get; set; }
        public bool IsSystemAccount { get; set; }
        public bool IsArchive { get; set; }

        public Guid? ParentAccountId { get; set; }
        public Account ParentAccount { get; set; }

        public Guid TypeId { get; set; }
        public virtual AccountType Type { get; set; }

        public decimal? OpeningBalance { get; set; }
        public decimal? CurrentBalance { get; set; }

        public DateTimeOffset? LastReconciledDate { get; set; }
        public DateTimeOffset? LastTransactionDate { get; set; }

    }
}
