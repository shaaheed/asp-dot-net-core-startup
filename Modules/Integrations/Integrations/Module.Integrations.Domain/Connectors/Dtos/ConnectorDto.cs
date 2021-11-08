using Module.Integrations.Entities;
using Msi.Domain.Abstractions;
using System;
using System.Linq.Expressions;

namespace Module.Integrations.Domain
{
    public class ConnectorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IdNameDto Provider { get; set; }

        public string State { get; set; }
        public string Scope { get; set; }
        public string ApiKey { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Connector, ConnectorDto>> Selector()
        {
            return x => new ConnectorDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Provider = new IdNameDto
                {
                    Id = x.ProviderId,
                    Name = x.Provider.Name
                },
                State = x.State,
                Scope = x.Scope,
                ApiKey = x.ApiKey,
                ClientId = x.ClientId,
                ClientSecret = x.ClientSecret,
                RedirectUri = x.RedirectUri,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
