using Module.Systems.Entities;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Column(TypeName = "decimal(18,4)")]
        public decimal? OpeningBalance { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? CurrentBalance { get; set; }

        public DateTimeOffset? LastReconciledDate { get; set; }
        public DateTimeOffset? LastTransactionDate { get; set; }

    }
}
