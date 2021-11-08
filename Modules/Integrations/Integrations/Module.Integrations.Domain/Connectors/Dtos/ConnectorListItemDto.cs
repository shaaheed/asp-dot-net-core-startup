using Module.Integrations.Entities;
using Msi.Domain.Abstractions;
using System;
using System.Linq.Expressions;

namespace Module.Integrations.Domain
{
    public class ConnectorListItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IdNameDto Provider { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Connector, ConnectorListItemDto>> Selector()
        {
            return x => new ConnectorListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Provider = new IdNameDto
                {
                    Id = x.ProviderId,
                    Name = x.Provider.Name
                },
                CreatedAt = x.CreatedAt
            };
        }
    }
}
