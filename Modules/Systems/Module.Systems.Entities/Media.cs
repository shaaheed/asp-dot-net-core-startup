using Msi.Data.Entity;

namespace Module.Systems.Entities
{
    public class Media : BaseEntity
    {
        public string Title { get; set; }
        // in bytes
        public double Size { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
    }
}
