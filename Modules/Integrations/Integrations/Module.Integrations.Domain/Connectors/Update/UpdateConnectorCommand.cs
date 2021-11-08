using System;

namespace Module.Integrations.Domain
{
    public class UpdateConnectorCommand : CreateConnectorCommand
    {
        public Guid Id { get; set; }
    }
}
