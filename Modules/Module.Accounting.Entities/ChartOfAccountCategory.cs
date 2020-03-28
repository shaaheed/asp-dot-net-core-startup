using Core.Interfaces.Entities;

namespace Module.Accounting.Entities
{
    public class ChartOfAccountCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }
}
