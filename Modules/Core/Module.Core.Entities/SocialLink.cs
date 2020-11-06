using Msi.Data.Entity;
using System;

namespace Module.Core.Entities
{
    public class SocialLink : BaseEntity
    {
        public string Link { get; set; }
        public Guid LinkTypeId { get; set; }
        public SocialLinkType LinkType { get; set; }
    }
}
