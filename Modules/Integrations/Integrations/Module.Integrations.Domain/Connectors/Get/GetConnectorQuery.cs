using Msi.Mediator.Abstractions;
using System;

namespace Module.Integrations.Domain
{
    public class GetConnectorQuery : IQuery<ConnectorDto>
    {
        public Guid Id { get; set; }
    }
}
