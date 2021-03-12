using Module.Core.Entities;
using System;

namespace Module.Sales.Entities
{
    public class ChartOfAccount : CodeNameEntity
    {
        public string Description { get; set; }
        public bool IsEditable { get; set; }
        public bool IsDeletable { get; set; }

        public Guid CategoryId { get; set; }
        public ChartOfAccountCategory Category { get; set; }

        public Guid TypeId { get; set; }
        public ChartOfAccountType Type { get; set; }

    }
}
