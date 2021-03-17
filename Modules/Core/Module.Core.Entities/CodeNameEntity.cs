using Msi.Data.Entity;

namespace Module.Core.Entities
{
    [IgnoredEntity]
    public class CodeNameEntity : NameEntity
    {
        public string Code { get; set; }
    }
}
