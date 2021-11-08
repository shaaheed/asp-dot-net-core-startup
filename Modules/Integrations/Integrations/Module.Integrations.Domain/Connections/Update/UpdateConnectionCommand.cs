using System;

namespace Module.Integrations.Domain
{
    public class UpdateConnectionCommand : CreateConnectionCommand
    {
        public Guid Id { get; set; }
    }
}
