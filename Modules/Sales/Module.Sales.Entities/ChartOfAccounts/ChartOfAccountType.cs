using Module.Core.Entities;
using System;

namespace Module.Sales.Entities
{
    public class ChartOfAccountType : CodeNameEntity
    {
        public string UseOf { get; set; }

        public Guid CategoryId { get; set; }
        public ChartOfAccountCategory Category { get; set; }

    }
}
