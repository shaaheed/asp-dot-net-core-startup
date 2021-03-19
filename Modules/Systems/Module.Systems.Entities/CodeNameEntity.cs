using Msi.Data.Entity;

namespace Module.Systems.Entities
{
    [IgnoredEntity]
    public class CodeNameEntity : NameEntity
    {
        public string Code { get; set; }
    }
}
