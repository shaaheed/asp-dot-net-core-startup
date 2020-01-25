using Core.Interfaces.Entities;

namespace Module.Core.Entities
{
    public class Media : BaseEntity
    {
        public string Caption { get; set; }

        public int FileSize { get; set; }

        public string FileName { get; set; }

        public MediaType MediaType { get; set; }
    }
}
