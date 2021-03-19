using Module.Systems.Entities;
using System;

namespace Module.Sales.Entities
{
    public class ChartOfAccount : CodeNameEntity
    {
        public string Description { get; set; }
        public bool IsEditable { get; set; }
        public bool IsDeletable { get; set; }

        public Guid TypeId { get; set; }
        public virtual ChartOfAccountType Type { get; set; }

    }
}
