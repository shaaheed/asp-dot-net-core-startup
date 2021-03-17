using Msi.Data.Entity;

namespace Module.Core.Entities
{
    [IgnoredEntity]
    public class NameEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
