using Msi.Data.Entity;

namespace Module.Core.Entities
{
    public class Currency : BaseEntity
    {
        public string Code3 { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Plural { get; set; }
    }
}
