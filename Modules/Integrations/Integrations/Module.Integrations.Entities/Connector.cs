using Msi.Data.Entity;
using System;

namespace Module.Integrations.Entities
{
    public class Connector : OrganizationEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid ProviderId { get; set; }
        public virtual Provider Provider { get; set; }

        public string State { get; set; }
        public string Scope { get; set; }
        public string ApiKey { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
