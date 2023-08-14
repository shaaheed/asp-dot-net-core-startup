using Module.Systems.Entities;
using System;

namespace Module.Sales.Entities
{
    public class Approval : OrganizationCodeNameEntity
    {
        public ApprovalStatus Status { get; set; }
        public string Note { get; set; }
        public Guid? NextApproverId { get; set; }
        // public Employee NextApprover { get; set; }
    }
}
