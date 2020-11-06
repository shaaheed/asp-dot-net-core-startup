using Msi.Data.Entity;
using System;

namespace Module.Core.Entities
{
    public class District : BaseEntity
    {
        public District() { }

        public District(Guid id)
        {
            Id = id;
        }

        public long StateOrProvinceId { get; set; }

        public StateOrProvince StateOrProvince { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }
    }
}
