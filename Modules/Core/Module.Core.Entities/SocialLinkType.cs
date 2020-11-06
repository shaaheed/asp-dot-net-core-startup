using Msi.Data.Entity;

namespace Module.Core.Entities
{
    public class SocialLinkType : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
