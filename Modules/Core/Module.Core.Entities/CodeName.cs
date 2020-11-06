using Msi.Data.Entity;

namespace Module.Core.Entities
{
    [IgnoredEntity]
    public class CodeName : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
