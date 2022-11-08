using Msi.Data.Entity;
using Module.Systems.Entities;

namespace Module.Sales.Entities
{
    public class Order : OrganizationEntity
    {
        public Guid? CustomerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Guid? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public Guid? ApprovalId { get; set; }
        public virtual Approval Approval { get; set; }

    }
}
