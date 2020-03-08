using Core.Interfaces.Entities;

namespace Module.Accounting.Entities
{
    public class ChartOfAccount : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

    }
}
