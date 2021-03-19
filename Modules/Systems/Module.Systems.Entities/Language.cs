using Msi.Data.Entity;

namespace Module.Systems.Entities
{
    public class Language : BaseEntity
    {
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string Description { get; set; }
    }
}
