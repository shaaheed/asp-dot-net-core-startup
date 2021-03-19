using Msi.Data.Entity;
using System;

namespace Module.Systems.Entities
{
    public class District : BaseEntity
    {
        public District() { }

        public District(Guid id)
        {
            Id = id;
        }

        public Guid StateOrProvinceId { get; set; }
        public virtual StateOrProvince StateOrProvince { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
    }
}
