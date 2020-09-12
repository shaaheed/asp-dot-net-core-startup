using Core.Infrastructure.Attributes;
using Core.Interfaces.Entities;

namespace Module.Core.Entities
{
    [IgnoredEntity]
    public class CodeName : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
