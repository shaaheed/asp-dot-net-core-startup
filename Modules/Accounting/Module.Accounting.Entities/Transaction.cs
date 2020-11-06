using Msi.Data.Entity;

namespace Module.Accounting.Entities
{
    public class Transaction : BaseEntity
    {
        public string Description { get; set; }
        public string Notes { get; set; }

        public bool IsReviewed { get; set; }

        //public long AccountId { get; set; }
        //public ChartOfAccount Account { get; set; }

        public TransactionType Type { get; set; }

    }
}
