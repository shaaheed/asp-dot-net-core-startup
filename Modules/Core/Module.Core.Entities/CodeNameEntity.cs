using Msi.Data.Entity;

namespace Module.Core.Entities
{
    [IgnoredEntity]
    public class CodeNameEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
