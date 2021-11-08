using Module.Integrations.Entities;
using Msi.Domain.Abstractions;
using System;
using System.Linq.Expressions;

namespace Module.Integrations.Domain
{
    public class ConnectionDto
    {
        public Guid Id { get; set; }
        public IdNameDto Connector { get; set; }

        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public string TenantId { get; set; }

        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountPhoto { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTimeOffset LastUsedAt { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Connection, ConnectionDto>> Selector()
        {
            return x => new ConnectionDto
            {
                Id = x.Id,
                TokenType = x.TokenType,
                AccessToken = x.AccessToken,
                Connector = new IdNameDto
                {
                    Id = x.ConnectorId,
                    Name = x.Connector.Name
                },
                ExpiresIn = x.ExpiresIn,
                RefreshToken = x.RefreshToken,
                TenantId = x.TenantId,
                AccountId = x.AccountId,
                AccountName = x.AccountName,
                AccountPhoto = x.AccountPhoto,
                IsActive = x.IsActive,
                LastUsedAt = x.LastUsedAt,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
