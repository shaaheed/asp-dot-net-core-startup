using Msi.Data.Entity;
using System;

namespace Module.Integrations.Entities
{
    public class Connection : OrganizationEntity
    {
        public Guid ConnectorId { get; set; }
        public virtual Connector Connector { get; set; }

        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public string TenantId { get; set; }

        // OrganizationId/CompanyId etc
        // Suppose Gmail account can be connected using a multiple gmail connector and this field contains email address as email is unique across the gmail system.
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountPhoto { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTimeOffset LastUsedAt { get; set; }
    }
}
