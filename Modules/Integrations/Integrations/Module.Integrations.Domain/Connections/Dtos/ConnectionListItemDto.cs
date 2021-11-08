using Module.Integrations.Entities;
using Msi.Domain.Abstractions;
using System;
using System.Linq.Expressions;

namespace Module.Integrations.Domain
{
    public class ConnectionListItemDto
    {
        public Guid Id { get; set; }
        public IdNameDto Connector { get; set; }
        public IdNameDto Provider { get; set; }

        public string AccountId { get; set; }
        public string AccountName { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTimeOffset LastUsedAt { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Connection, ConnectionListItemDto>> Selector()
        {
            return x => new ConnectionListItemDto
            {
                Id = x.Id,
                AccountId = x.AccountId,
                AccountName = x.AccountName,
                Provider = new IdNameDto
                {
                    Id = x.Connector.ProviderId,
                    Name = x.Connector.Provider.Name
                },
                Connector = new IdNameDto
                {
                    Id = x.ConnectorId,
                    Name = x.Connector.Name
                },
                IsActive = x.IsActive,
                LastUsedAt = x.LastUsedAt,
                CreatedAt = x.CreatedAt,
            };
        }
    }
}
